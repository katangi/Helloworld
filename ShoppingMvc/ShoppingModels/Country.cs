using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMvc.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter CountryName")]
        public string CountryName { get; set; }
    }
}