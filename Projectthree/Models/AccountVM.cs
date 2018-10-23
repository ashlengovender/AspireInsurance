using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace Projectthree.Models
{
    public class AccountVM
    {

        [Key]
        [Display(Name = "Account Number")]
        [Required(ErrorMessage = " ")]

        public string AccNum { get; set; }

        [Display(Name = "Customer ID Number")]
        [Required(ErrorMessage = " ")]
        public string CustID { get; set; }

        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }









    }
}