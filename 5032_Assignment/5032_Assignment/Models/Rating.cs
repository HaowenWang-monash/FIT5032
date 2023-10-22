namespace _5032_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        public int RatingID { get; set; }

        public int DoctorID { get; set; }

        [Column("Rating")]
        public int Rating1 { get; set; }

        [ForeignKey("DoctorID")]
        public virtual Doctor Doctors { get; set; }
    }
}
