using AgentieTorism.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcelLibrary.SpreadSheet;
using System.Data.SqlClient;

namespace AgentieTorism.Controllers
{
    public class ExcelController : Controller,Export
    {
        public VacanteDBContext vdb = new VacanteDBContext();
        public DataTable data = new DataTable();
        // GET: /Excel/
        public ActionResult Index()
        {
            return View();
        }

        public void export()
        {
            
            string file = @"D:\sem2\Result";

            string con = @"Data Source= (LocalDB)\v11.0;" + 
                            @"AttachDbFilename=|DataDirectory|\Vacante.mdf;
                            Integrated Security=True";

            string queryString = "Select * FROM Vacantes ;"; 

            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(queryString, connection);

                command.ExecuteNonQuery();
                if (data.Rows.Count != 0)
                {
                    adapter.Fill(data);

                }
                else
                {
                    RedirectToAction("Index", "Home");
                }
                connection.Close();
            }
            


            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("first");
            for (int i = 0; i < data.Columns.Count; i++)
            {
                worksheet.Cells[0, i] = new Cell(data.Columns[i].ColumnName);

                // Populate row data
                for (int j = 0; j < data.Rows.Count; j++)
                    worksheet.Cells[j + 1, i] = new Cell(data.Rows[j][i]);
            }
            workbook.Worksheets.Add(worksheet);

            workbook.Save(file);
            RedirectToAction("Contact", "Home");
        }

	}
}