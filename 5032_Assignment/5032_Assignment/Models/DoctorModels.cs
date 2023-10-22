using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _5032_Assignment.Models
{
    public partial class DoctorModels : DbContext
    {
        public DoctorModels()
            : base("name=DoctorModels1")
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<_5032_Assignment.Models.Images> Images { get; set; }
    }
}
