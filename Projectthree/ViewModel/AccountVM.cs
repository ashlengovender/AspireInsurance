using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace Projectthree.ViewModel
{
    public class AccountVM
    {
        [Key]
        public int AccNum { get; set; }

        //CustomerTB
        public string CustID { get; set; }

        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        //vehicleTB
        [Display(Name = "Policy ID")]
        [Required(ErrorMessage = " ")]

        public string PolicyID { get; set; }

        //vehicle pricingTB
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}