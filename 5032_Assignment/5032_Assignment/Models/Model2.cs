using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _5032_Assignment.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Image_model")
        {
        }

        public virtual DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Images>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<Images>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
