using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ShoppingMvc.Models
{
    public class State
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter StateName")]
        public string StateName { get; set; }
        [Required(ErrorMessage = "Please Select Country Name")]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}