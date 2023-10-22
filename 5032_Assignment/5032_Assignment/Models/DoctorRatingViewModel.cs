using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5032_Assignment.Models
{
    public class DoctorRatingViewModel
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public double AverageRating { get; set; }
    }

}