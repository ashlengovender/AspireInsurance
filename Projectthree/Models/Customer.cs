using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using System.Net.Mail;



namespace Projectthree.Models
{
    public class Customer
    {

        // search for customer screen use code from other app try it

        [Key]
        [Display(Name = "Customer ID Number")]
        [StringLength(13)]
        [Required(ErrorMessage = "Invalid ID Number")]

        public string CustID { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        //  [DataType(DataType.Date)] // to enter date
        //[DataType(DateType.Currency)]

        [Display(Name = "Cell Number")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string CellNum { get; set; }

        [Display(Name = "Home Number")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string HomeNum { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public virtual Vehicle Vehicles { get; set; }
        public virtual Claim Claims { get; set; }



        public static void BuildEmailTemplate(string sendto)
        {
            string from, to, bcc, cc, subject, body;
            from = "aspireinsurances@gmail.com"; //makeemail
            to = sendto.Trim();
            bcc = "";
            cc = "";
            subject = "New Aspire Customer";
            StringBuilder sb = new StringBuilder();
            sb.Append("You Have Been Registered As A Customer At Aspire Insurance.");
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }


        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("aspireinsurances@gmail.com", "Aspireinsurances1");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}