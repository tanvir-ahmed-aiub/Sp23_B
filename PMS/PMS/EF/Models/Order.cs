using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.EF.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string OrderedBy { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order() {
            OrderDetails = new List<OrderDetail>();
        }
    }
}