using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMvc.Models
{
   public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
   
        public string UserName { get; set; }
        public string Address { get; set; }
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Please fill CVC No")]
        public int CvcNo { get; set; }
        [Required(ErrorMessage = "Card Number has 16 digits")]
        public int CreditCardNo { get; set; }
        [Required(ErrorMessage = "Please Select Expiry Date")]
        public DateTime ExpityDate { get; set; }

        public DateTime Orderdate { get; set; }
       
        public int TotalOrder { get; set; }

    }
}
