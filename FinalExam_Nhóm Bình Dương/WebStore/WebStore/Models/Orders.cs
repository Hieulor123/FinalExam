using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class Orders
    {
        public string OrderID { get; set; }
        public string UserName { get; set; }
        public int OrderPrice { get; set; }
        public int OrderStatus { get; set; }

    }
}
