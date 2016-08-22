using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMvc.Models
{
  public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please Enter UserName")]
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter ProductName")]
        public string ProductName { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        public Decimal Price { get; set; }

        //[DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime OrderDate { get; set; }
    }
}
