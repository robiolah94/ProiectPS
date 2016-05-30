using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgentieTorism.Models
{
    public class Rezervari
    {
        [Key]
        public int RezervareiD { get; set; }
        public String vacante { get; set; }
        public DateTime data { get; set; }
        public int nrpersoane { get; set; }
    }

    public class RezervariDBContext : DbContext
    {
        public DbSet<Rezervari> Rezervari { get; set; }

    }
}