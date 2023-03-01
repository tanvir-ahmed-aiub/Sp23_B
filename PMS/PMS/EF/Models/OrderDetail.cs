using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS.EF.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OId { get; set; }
        [ForeignKey("Product")]
        public int PId { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product{ get; set; }
    }
}