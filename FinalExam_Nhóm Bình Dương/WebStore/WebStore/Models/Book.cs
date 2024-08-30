using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class Book
    {
        public string BookID { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string BookTypeID { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Nxb { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int OrderedQuantity { get; set; }


    }
}
