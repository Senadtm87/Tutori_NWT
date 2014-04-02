using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boo1.Models
{
    public class KorisnikModel
    {
        [Required]
        [StringLength(150)]
        [Display(Name = "Username: ")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string password { get; set; }
    }
}