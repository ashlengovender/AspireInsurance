using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Projectthree.Models
{
    public class AutoId
    {

        [Key]
        public string IdName { get; set; }
        [Required]
        public int Id { get; set; }
       


    }
}