using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Projectthree.Models
{
    public class Vehicle
    {

        [Key]
        [Display(Name = "Policy ID")]
       

        public string PolicyID { get; set; }




        [Display(Name = "Customer ID Number")]
        [Required(ErrorMessage = "Enter 13 digits")]
        [StringLength(13)]
      
        public string CustID { get; set; }

        [Display(Name = "Primary Driver Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string PDriverName { get; set; }

        [Display(Name = "Driver Licence Number")]   //12 characters
        public string PDLicenceNum { get; set; }

        [Display(Name = "Secondary Driver Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string SDriverName { get; set; }
        [Display(Name = "Driver Licence Number")]
        public string SDLicenceNum { get; set; }

        [Display(Name = "Vehicle Make")]

        public string Make { get; set; }

        [Display(Name = "Vehicle Model")]
        public string Model { get; set; }

        [Display(Name = "Vehicle Model Year")]
        public string year { get; set; }

        [Display(Name = "Vehicle Regerstarion Number")]
        public string RegNum { get; set; }

        [Display(Name = "Vin Number")]
        public string VinNum { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }


        [Display(Name = "3rd Party Insurance")]
        public bool party3 { get; set; }
        [Display(Name = "Comprehensive Insurance")]
        public bool Compre { get; set; }
        [Display(Name = "Engine Plan")]
        public bool Engineplan { get; set; }
        [Display(Name = "WriteOff")]
        public bool writeoff { get; set; }

        //price????
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public double Pricex { get; set; }


        public virtual ICollection<Customer> Customers { get; set; }

        public double getPrice()
        {
         
            
            
            double part3=2000;
            double comp = 3500;
            double engpl = 2200;
            double writeof = 3000;
            double prix = 0;
            if (party3==true)
            {
                prix += part3;
                
            }

            if (Compre == true)
            {
                prix += comp;

            }
            if (Engineplan == true)
            {
                prix +=engpl;

            }
            if (writeoff == true)
            {
                prix += writeof;

            }
            
            return prix;
        }
        
        public string determinkey()
        {
            Random ran = new Random();
            string r = "";
            string firstTwo = PDriverName.Substring(0, 3);
            int randomOne = ran.Next(1, 101);
            int randomTwo = ran.Next(101, 201);
            int diff = randomOne + randomTwo;
            string d = Convert.ToString(diff);
            r = d + firstTwo;

            return r;

        }




    }
}