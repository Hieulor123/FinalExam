using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class OrderItem
    {
        public string ItemID { get; set; }
        public string OrderID { get; set; }
        public string BookID { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int Discount { get; set; }

    }
}
