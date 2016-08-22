using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingMvc.Areas.Product.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
   
        public int categoryId { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public float price { get; set; }
        public int Quantity { get; set; }

    }
}