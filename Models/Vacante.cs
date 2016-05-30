using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace AgentieTorism.Models
{
    public class Vacante
    {
        [Key]
        public int VacanteiD { get; set; }
        public String Tara { get; set; }
        public String Destinatia { get; set; }
        public String Duratasejur { get; set; }
        public String transport { get; set; }
        public String pachet { get; set; }
        public DateTime plecare { get; set; }
        public int locuridisponible { get; set; }
       // public String photo { get; set; }
    }

    public class VacanteDBContext : DbContext
    {
        public DbSet<Vacante> Vacante { get; set; }
    }
}