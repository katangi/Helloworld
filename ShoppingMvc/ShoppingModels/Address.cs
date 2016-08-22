using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMvc.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Select User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Select Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Select Country")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please Select State")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please Select City")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Please Select State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Select City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string userAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Pin Code")]
        public int Pin { get; set; }
        [Required(ErrorMessage = "Please Enter AddressType")]
        public string Addresstype { get; set; }

    }
}
