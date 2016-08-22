using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMvc.Models;
using BussinessLayer;

namespace ShoppingMvc.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        OrderDetailsBL orderdetailBL = new OrderDetailsBL();
        ProductBL productBL = new ProductBL();
        OrderBL orderBL = new OrderBL();
        string getName;
        int id;
        public ActionResult Index()

        {
            ViewBag.Status = TempData["Status"];
            ViewBag.Type = TempData["Type"];
            if (Session["username"] != null)
            {
                 getName = Session["username"].ToString();
                ViewBag.userName = getName;
            }
            else
            {
                return RedirectToAction("Login", "User", new { area = "User" });
            }
            List<ShoppingMvc.Models.Orders> orderlist = orderBL.GetAllOrderde();

            ShoppingMvc.Models.Orders order = new ShoppingMvc.Models.Orders();
          
            List<OrderDetails> orderdetaillist = orderdetailBL.GetAllOrderdetail();
            return View(orderdetaillist);
        }

        public ActionResult Create()
        {

            ShoppingMvc.Models.OrderDetails orderdetail = new ShoppingMvc.Models.OrderDetails();
            List<ShoppingMvc.Models.Product> ProductList = productBL.GetAllProduct();

            ViewBag.ProducttName = ProductList;

            return PartialView("AddEditOrder", orderdetail);

        }

        public ActionResult Edit(int id)
        {

            ShoppingMvc.Models.OrderDetails orderdetail = new ShoppingMvc.Models.OrderDetails();

            if (id != 0)
            {
                orderdetail = orderdetailBL.GetOrderDetailById(id);
                List<ShoppingMvc.Models.Product> ProductList = productBL.GetAllProduct();
                var pList = ProductList.Select(m => new SelectListItem() { Text = m.Name, Value = m.Id.ToString() });

                ViewBag.MyList = pList;
            }

            return PartialView("AddEditOrder", orderdetail);

        }

        [HttpPost]
        public ActionResult Create(ShoppingMvc.Models.OrderDetails orderdetail,string text)
        {

            try
            {
                if (orderdetail.Id != 0)
                {
                    orderdetail.OrderDate = Convert.ToDateTime(text);
                    int a = orderdetailBL.UpdateOrderDetail(orderdetail);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been update successfully";
                        TempData["Type"] = "success";
                    }

                }
                else
                {
                    orderdetail.OrderDate =Convert.ToDateTime(text);
                    int a = orderdetailBL.SaveOrderDetail(orderdetail);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been added successfully";
                        TempData["Type"] = "success";

                    }
                }

            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
            }
            return RedirectToAction("Index", "Order", new { area = "Admin" });
        }
    }
}