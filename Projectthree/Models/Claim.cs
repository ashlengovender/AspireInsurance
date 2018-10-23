using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Projectthree.Models
{
    public class Claim
    {
        [Key]
        [Display(Name = "Report Number")]
        [Required(ErrorMessage = " ")]
       
        public int ReportNum { get; set; }

        [Display(Name = "Customer ID Number")]
        [StringLength(13)]
        [Required(ErrorMessage = "Invalid ID Number")]
        public string CustID { get; set; }

        [Display(Name = "Policy ID of damaged Vehicle")]
        [Required(ErrorMessage = " ")]
        public string ClaimPolicyID { get; set; } // used to pull vehicle from vehicles

        [Display(Name = "Date of Incident")]
        [DataType(DataType.Date)]
        public DateTime DateOI { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Name Of Drive Involved")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string DriverName { get; set; }

        [Display(Name = "Damage Description")]

        public string DamageDescription { get; set; }

        [Display(Name = "Quoted Amount of damage")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        //  [DataType(DataType.Date)] // to enter date
        //[DataType(DateType.Currency)]



        /*  public int Randomizer()
          {


              Random rand = new Random();
              ReportNum = rand.Next();
              return ReportNum;

          }*/
        public int Determinkeyz()
        {
            Random ran = new Random();
            
          
            int randomOne = ran.Next(1, 101);
            int randomTwo = ran.Next(101, 201);
            
            int diff = randomOne - randomTwo;
            
            return diff;

        }




    }
}