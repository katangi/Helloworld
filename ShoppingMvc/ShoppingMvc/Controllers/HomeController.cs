using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMvc.Models;
using BussinessLayer;

namespace ShoppingMvc.Controllers
{
   
    public class HomeController : Controller
    {
        ProductBL productBL = new ProductBL();
        public ActionResult Index()
        {

            return RedirectToAction("ProductIndex", "Product", new { area = "Product" });
        }
     
        public ActionResult About()
        {
            ViewBag.Message = "my name is prerna";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your";

            return View();
        }
    }
}