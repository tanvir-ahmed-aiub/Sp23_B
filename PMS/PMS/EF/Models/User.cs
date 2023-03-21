using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.EF.Models
{
    public class User
    {
        [Key]
        [StringLength(10)]
        public string Username { get; set; }
        [Required]
        [StringLength (20)]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }
        

    }
}