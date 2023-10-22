using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _5032_Assignment.Models
{
    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=Appointment")
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<_5032_Assignment.Models.Location> Locations { get; set; }
    }
}
