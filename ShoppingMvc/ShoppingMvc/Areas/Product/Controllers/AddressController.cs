using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMvc.Models;
using BussinessLayer;

namespace ShoppingMvc.Areas.Product.Controllers
{
    public class AddressController : Controller
    {
        // GET: Product/Address
        AddressBL addressBL = new AddressBL();
        UserBL userBL = new UserBL();
        CountryBL countryBL = new CountryBL();
        StateBL stateBL = new StateBL();
        CityBL cityBL = new CityBL();

        List<OrderDetails> orderdetaillist = new List<OrderDetails>();
        OrderBL orderBL = new OrderBL();
        OrderDetailsBL orderdetailBL = new OrderDetailsBL();
        string getName;
        int Id;
        ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                getName = Session["username"].ToString();
            }
                   

            List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

            user = userList.FirstOrDefault(x => x.UserName == getName);
            Session["Id"] = user.Id;
            List<ShoppingMvc.Models.Address> addresslist = addressBL.GetAddressById(user.Id);
               if(addresslist!=null)
            {
                if (Session["sum"] != null)
                {
                    ViewBag.sum = Session["sum"].ToString();
                    List<OrderDetails> orderdetaillist = Session["orderDetail"] as List<OrderDetails>;
                    ViewBag.MyList = orderdetaillist;
                }
                return View("Index", addresslist);
            }

            
            return RedirectToAction("Index", "Address", new { area = "Address" });
            
        }
     

      
        public ActionResult ProceedDetail()
        {
            ShoppingMvc.Models.Orders orders = new ShoppingMvc.Models.Orders();
            string getName = Session["username"].ToString();
            ShoppingMvc.Models.Address address = new ShoppingMvc.Models.Address();
            List<ShoppingMvc.Models.Address> addressList = addressBL.GetAllAddress();

            address = addressList.FirstOrDefault(x => x.UserName == getName);

            ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();

            List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

            user = userList.FirstOrDefault(x => x.UserName == getName);

            Orders order = new Orders()
            {
                UserId = user.Id,
                AddressId = address.Id,
                TotalOrder =Convert.ToInt32(Session["sum"]),
                Orderdate = Convert.ToDateTime(DateTime.Today.ToString())
            };

            orderBL.SaveOrder(order);

            ShoppingMvc.Models.Orders orderId = new ShoppingMvc.Models.Orders();
            int b = orderBL.MaxId(orderId);

            int ID = b;

            var detail = Session["orderDetail"].ToString();
            List<OrderDetails> orderdetaillist = Session["orderDetail"] as List<OrderDetails>;

            //  var i = orderdetaillist.FirstOrDefault(x => x.ProductId == ProductId);
            for (var a = 0; a < orderdetaillist.Count; a++)
            {
                OrderDetails orderdetail = new OrderDetails
                {
                    OrderId = ID,
                    Price = orderdetaillist[a].Price,
                    ProductId = orderdetaillist[a].ProductId,

                    Quantity = orderdetaillist[a].Quantity,
                    OrderDate = Convert.ToDateTime(DateTime.Today.ToString())

                };

                orderdetailBL.SaveOrderDetail(orderdetail);

            }
            return RedirectToAction("Index", "Transaction", new { area = "Product" });
        }

     

        public ActionResult MyAddress()
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

            ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();
            List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();
            
            user = userList.FirstOrDefault(x => x.UserName == getName);
            List<ShoppingMvc.Models.Address> addressList = addressBL.GetAddressById(user.Id);
            return View(addressList);
        }

        public ActionResult Create()
        {
            ShoppingMvc.Models.Address address = new ShoppingMvc.Models.Address();

            //List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

            //ViewBag.UserName = userList;
            //List<ShoppingMvc.Models.Country> CountryList = countryBL.GetAllCountry();

            //ViewBag.Country = CountryList;
            //List<ShoppingMvc.Models.State> StateList = stateBL.GetAllState();

            //ViewBag.State = StateList;
            //List<ShoppingMvc.Models.City> CityList = cityBL.GetAllCity();

            //ViewBag.City = CityList;
            return PartialView("AddEditAddress", address);

        }

        public ActionResult Edit(int id)
        {
            ShoppingMvc.Models.Address address = new ShoppingMvc.Models.Address();

            if (id != 0)
            {

                address = addressBL.BindAddressById(id);
              }

            return PartialView("AddEditAddress", address);

        }

        [HttpPost]
        public ActionResult Create(ShoppingMvc.Models.Address address)
        {

            try
            {
                if (address.Id != 0)
                {

                    int a = addressBL.UpdateAddress(address);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been update successfully";
                        TempData["Type"] = "success";
                    }

                }
                else
                {
                    ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();
                    List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();
                    getName = Session["username"].ToString();
                    user = userList.FirstOrDefault(x => x.UserName == getName);
                  
                    address.UserId = user.Id;
                    int a = addressBL.SaveAddress(address);
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
            return RedirectToAction("MyAddress", "Address", new { area = "Product" });
        }
    }
}