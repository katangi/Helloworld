using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Select CategoryName")]
        public int categoryId { get; set; }
        public string Categoryname { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        public string Desc { get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        public Decimal price { get; set; }
        [Required(ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please Select Image")]
        //[FileExtensions(Extensions = "jpg,png,jpeg,gif", ErrorMessage = "Please upload valid format")]
        public string Image { get; set; }
    


    }
}