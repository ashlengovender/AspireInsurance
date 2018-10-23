using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace Projectthree.Models
{
    public class VehiclePricing
    {





        [Key]
        
        [Display(Name = "PriceID")]
        public int PID { get; set; }

        [Display(Name = "Vehicle Make")]
        public string Make { get; set; }

        [Display(Name = "Vehicle Model")]
        public string Model { get; set; }

        [Display(Name = "Vehicle Model Year")]
        public string year { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}