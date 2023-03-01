using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS.EF.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public double  Price { get; set; }
        public int Qty { get; set; }
        [ForeignKey("Category")]
        public int CId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail>OrderDetails { get; set; }
        public Product() { 
            OrderDetails = new List<OrderDetail>();
        }
    }
}