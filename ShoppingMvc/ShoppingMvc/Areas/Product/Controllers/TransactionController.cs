using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMvc.Models;
using BussinessLayer;

namespace ShoppingMvc.Areas.Product.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Product/Transaction
        OrderBL orderBL = new OrderBL();
        UserBL userBL = new UserBL();
        public ActionResult Index()
        {

            ShoppingMvc.Models.Orders order = new ShoppingMvc.Models.Orders();
            return View(order);

            //this should be the Primary key
        }
        [HttpPost]
        public ActionResult Index(ShoppingMvc.Models.Orders order)
        {
            string getName = Session["username"].ToString();
            ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();
            List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

            user = userList.FirstOrDefault(x => x.UserName == getName);
            order.UserId = user.Id;
            if (user.Id != 0)

            {
                int a = orderBL.SaveCardDetail(order);
            }



            return RedirectToAction("Login", "User", new { area = "User" });
        }


    }
    }
    

