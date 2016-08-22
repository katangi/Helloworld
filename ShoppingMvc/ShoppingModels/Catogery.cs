using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMvc.Models
{ 
    public class Catogery
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter CategoryName")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
    }
}