using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _5032_Assignment.Models
{
    public partial class Model5 : DbContext
    {
        public Model5()
            : base("name=Rating_Model")
        {
        }

        public virtual DbSet<Rating> Rating { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
