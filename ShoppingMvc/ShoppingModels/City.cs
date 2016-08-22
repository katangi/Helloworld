using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ShoppingMvc.Models
{ 
    public class City
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter CityName")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Please Select StateName")]
        public int StateId { get; set; }
    }
}