using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShoppingMvc.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        // public string LastName { get; set; }


        [Remote("CheckUserEmailExists", "User", AdditionalFields = "Email, Id", ErrorMessage = "Already in use")]
        [RegularExpression(@"^([\w-\.]+)@(wwindia|neosofttech)\.com$", ErrorMessage = " The domain must be wwindia.com or neosofttech.com")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter PhoneNo")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please inter Numeric value")]
        [Display(Name = "PhoneNo")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Please Select City")]
        public int CityId { get; set; }
       
        public string CityName { get; set; }
        [Required(ErrorMessage = "Please Select State")]
        public int StateId { get; set; }
       
        public string StateName { get; set; }
        [Required(ErrorMessage = "Please Select Country")]
        public int CountryId { get; set; }
      //  [Required(ErrorMessage = "Please Select CountryName")]
        public string CountryName { get; set; }
        public string UserAddress { get; set; }
        public string Addresstype { get; set; }

        public bool  IsActive { get; set; }
    }
}