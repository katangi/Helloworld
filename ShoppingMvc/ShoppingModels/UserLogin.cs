using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMvc.Models
{
   public class UserLogin
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^([\w-\.]+)@(wwindia|neosofttech)\.com$", ErrorMessage = " The domain must be wwindia.com or neosofttech.com")]
        public string Email { get; set; }
       

        [Required(ErrorMessage = "Please Enter Password")]

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}
