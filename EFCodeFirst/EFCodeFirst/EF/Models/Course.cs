using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCodeFirst.EF.Models
{
    public class Course
    {
       
        public int CourseId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Department")]
        public int OfferdBy { get; set; }
        public virtual Department Department { get; set; }
    }
}