using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMvc.Models;
using BussinessLayer;
using System.Data;
using System.Windows.Forms;

namespace ShoppingMvc.Areas.Product.Controllers
{
    public class ProductController : Controller
    {
        string username;
        string getName;
        int count;
        static List<OrderDetails> cartlist = new List<OrderDetails>();
        List<OrderDetails> orderdetaillist = new List<OrderDetails>();
        // GET: Product/Product
        ProductBL productBL = new ProductBL();
        OrderDetailsBL orderdetailBL = new OrderDetailsBL();
        CategoryBL categoryBL = new CategoryBL();
        UserBL userBL = new UserBL();
        OrderBL orderBL = new OrderBL();
        AddressBL addressBL = new AddressBL();
        int Quantity = 0;

        public ActionResult ProductDetail(int id)
        {
            ViewBag.Status = TempData["Status"];
            ViewBag.Type = TempData["Type"];

            ShoppingMvc.Models.Product product = new ShoppingMvc.Models.Product();
            product = productBL.GetProductById(id);
            if (Session["username"] != null)
            {
                string getName = Session["username"].ToString();
                ViewBag.userName = getName;
                ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();
                List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

                user = userList.FirstOrDefault(x => x.UserName == getName);
                //List<Orders> orderlist = orderBL.GetAllOrderde();

                //var count = orderlist.Where(s => s.UserId == user.Id).Count();
                if (Session["cart"] != null)
                {
                    List<OrderDetails> orderdetaillist = Session["cart"] as List<OrderDetails>;
                    count = orderdetaillist.Where(s => s.ProductId == id).Count();
                }
            }

            return View(product);
        }
        //[HttpPost]
        //public JsonResult ProductSearch(string Prefix)

        //{
        //    //Note : you can bind same list from database  
        //    List<ShoppingMvc.Models.Product> productList = productBL.GetAllProduct();

        //    //Searching records from list using LINQ query  
        //    //var Product = (from N in productList
        //    //               where N.Name.StartsWith(Prefix)
        //    //                select new { N.Name });

        //    var product = (from N in productList where N.Name.StartsWith(Prefix) select N).ToList();
        //    Session["search"] = product;
        //    return Json(product, JsonRequestBehavior.AllowGet);
        //}


    public ActionResult UserIndex(string Search_Data)
        {
            List<ShoppingMvc.Models.Product> productList = productBL.GetAllProduct();

            if (Session["username"] != null)

            {
                if (Search_Data != null)
                {
                    var product = (from N in productList where N.Name.StartsWith(Search_Data) select N).ToList();
                    return View("UserIndex", product);

                }
                return View("UserIndex", productList);
            }
            else
            {
                return View("UserIndex", productList);
            }

           }
        public ActionResult ProductIndex(string Search_Data)
        {
            List<ShoppingMvc.Models.Product> productList = productBL.GetAllProduct();
            if (Search_Data != null)
            {
                var product = (from N in productList where N.Name.StartsWith(Search_Data) select N).ToList();
                return View("ProductIndex", product);
              
            }
            else {
                return View("ProductIndex", productList);
            }

        }
        public ActionResult Buy(int id)
        {
             Session["productId"] = id;
            if (Session["username"] != null)
            {
                return RedirectToAction("ProductDetail", "Product", new { area = "Product",id=id });
            }
            else
            {
                return RedirectToAction("Login", "User", new { area = "User" });
            }

        }
        public int AddCart(int itemId, Decimal price, string image, string name)
        {
            int Quantity;
            if (Session["username"] != null)
            {
                Session["Id"] = itemId;
                Session["price"] = price;
                string username = Session["username"].ToString();
                if (Session["cart"] == null)
                {
                    ShoppingMvc.Models.OrderDetails order1 = new ShoppingMvc.Models.OrderDetails();
                    order1.ProductId = itemId;
                    order1.Price = price;
                    order1.Quantity = 1;
                    order1.Image = image;
                    order1.ProductName = name;
                    cartlist.Add(order1);
                    Session["cart"] = cartlist;

                }

                else {
                    ShoppingMvc.Models.OrderDetails order = new ShoppingMvc.Models.OrderDetails();

                    if (itemId == Convert.ToInt32(Session["Id"]))
                    {
                        var i1 = cartlist.Find(product => product.ProductId == itemId);
                        if (i1 != null)
                        {
                            cartlist.FirstOrDefault(m => m.ProductId == itemId).Quantity = i1.Quantity + 1;
                            cartlist.FirstOrDefault(m => m.ProductId == itemId).Price = Convert.ToDecimal(Convert.ToDecimal(Session["price"]) * i1.Quantity);
                            cartlist.FirstOrDefault(m => m.ProductId == itemId).ProductName = i1.ProductName;
                        }
                        else {
                            order.ProductId = itemId;
                            order.Price = price;
                            order.Quantity = 1;
                            order.Image = image;
                            order.ProductName = name;
                            cartlist.Add(order);
                            Session["cart"] = cartlist;
                        }
                    }

                }
                List<OrderDetails> orderdetaillist = Session["cart"] as List<OrderDetails>;
                 count = orderdetaillist.Select(s => s.ProductId == itemId).Count();
                ViewBag.cartCount = count;
                Session["count"] = count;
               
                //    ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();

                //    List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

                //    user = userList.FirstOrDefault(x => x.UserName == username);

                //    ShoppingMvc.Models.Address address = new ShoppingMvc.Models.Address();
                //    List<ShoppingMvc.Models.Address> addressList = addressBL.GetAllAddress();

                //    address = addressList.FirstOrDefault(x => x.UserName == username);

                //    ShoppingMvc.Models.OrderDetails CheckOrderId = new ShoppingMvc.Models.OrderDetails();

                //    List<ShoppingMvc.Models.OrderDetails> orderList1 = orderdetailBL.GetAllOrderdetail();
                //    CheckOrderId = orderList1.FirstOrDefault(x => x.ProductId == itemId);
                //    if (CheckOrderId == null)
                //    {
                //        Orders order = new Orders()
                //        {
                //            UserId = user.Id,
                //            AddressId = address.Id,
                //            Orderdate = Convert.ToDateTime(DateTime.Today.ToString())
                //        };

                //        orderBL.SaveOrder(order);
                //    }



                //    ShoppingMvc.Models.Orders orderId = new ShoppingMvc.Models.Orders();
                //    int b = orderBL.MaxId(orderId);

                //    int ID = b;

                //    ShoppingMvc.Models.OrderDetails CheckProductId = new ShoppingMvc.Models.OrderDetails();

                //    List<ShoppingMvc.Models.OrderDetails> orderList = orderdetailBL.GetAllOrderdetail();
                //    CheckProductId = orderList.FirstOrDefault(x => x.ProductId == itemId);
                //    OrderDetails oborder = new OrderDetails()
                //    {
                //        Price = price,
                //        Quantity = Quantity,
                //        OrderDate = DateTime.Today,
                //        //OrderId = ID

                //    };

                //    if (CheckProductId != null)
                //    {
                //        OrderDetails oborder1 = new OrderDetails()
                //        {
                //            Id = CheckProductId.Id,
                //            Quantity = CheckProductId.Quantity + 1,
                //            Price = CheckProductId.Price + price,
                //            OrderDate = DateTime.Today,

                //        };

                //        orderdetailBL.UpdateOrderDetail(oborder1);

                //    }
                //    else if (CheckProductId == null)
                //    {
                //        OrderDetails oborder1 = new OrderDetails()
                //        {
                //            ProductId = itemId,
                //            Price = price,
                //            Quantity = 1,
                //            OrderDate = DateTime.Today,
                //            OrderId = ID

                //        };
                //        orderdetailBL.SaveOrderDetail(oborder1);
                //    }

                //    List<Orders> orderlist = orderBL.GetAllOrderde();
                //    var count = orderlist.Where(s => s.UserId == user.Id).Count();
                //    ViewBag.cartCount = count;
                //    return count;
            }

           
            return count;
        }

        public PartialViewResult EditQuantity()
        {
            //OrderDetails oborder = new OrderDetails()
            //{               
            //    Quantity = Quantity,
            //    OrderDate = DateTime.Today,
            //    Id = Id

            //};

            //orderdetailBL.UpdateOrderDetail(oborder);
            
            return PartialView(GetCartItems());
        }

        public JsonResult UpdateQuantity(int Id, int Quantity)
        {
            
            //ShoppingMvc.Models.OrderDetails CheckProductId = new ShoppingMvc.Models.OrderDetails();
            //List<ShoppingMvc.Models.OrderDetails> orderList = orderdetailBL.GetAllOrderdetail();
            //CheckProductId = orderList.FirstOrDefault(x => x.Id == Id);

            //int productId = CheckProductId.ProductId;

            //ShoppingMvc.Models.Product product = new ShoppingMvc.Models.Product();
            //List<ShoppingMvc.Models.Product> productList = productBL.GetAllProduct();
            //product = productList.FirstOrDefault(x => x.Id == productId);
            //decimal pprice = product.price;
            // List<OrderDetails> orderdetaillist = Session["cart"] as List<OrderDetails>;
            cartlist.FirstOrDefault(m=>m.ProductId==Id).Price= Convert.ToDecimal( Convert.ToDecimal(Session["price"])*Quantity);           
            cartlist.FirstOrDefault(m => m.ProductId == Id).Quantity = Quantity;
            //OrderDetails oborder = new OrderDetails()
            //{
            //    Quantity = Quantity,
            //    Price= pprice * Quantity,
            //    OrderDate = DateTime.Today,
            //    Id = Id

            //};

            //orderdetailBL.UpdateOrderDetail(oborder);

            return Json(true,JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetCartItems()
        {
            try {

                if (Session["username"] != null)
                {
                    username = Session["username"].ToString();
                }

                var sum = 0;
                ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();
                List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

                user = userList.FirstOrDefault(x => x.UserName == username);
                if (Session["cart"] == null)
                {
                    //TempData["Status"] = "Please Add Items";
                    //TempData["Type"] = "success";
                    //return RedirectToAction("ProductDetail");
                }
                
                
                // List<OrderDetails> orderdetaillist = orderdetailBL.GetCartById(user.Id);
                //if (orderdetaillist.Count == 0)
                //{
                //    Session["cart"] = null;
                //}
                else {
                    orderdetaillist = Session["cart"] as List<OrderDetails>;
                    foreach (var totalsum in orderdetaillist)
                    {
                        sum = Convert.ToInt32(sum + totalsum.Price);

                    }
                    ViewBag.Total = sum;
                    Session["sum"] = sum;
                    Session["orderDetail"] = orderdetaillist;
                    return PartialView("OrderDetail", orderdetaillist);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            if (Session["username"] != null)
            {
                string getName = Session["username"].ToString();
                ViewBag.userName = getName;
            }
            else
            {
                return RedirectToAction("Login", "User", new { area = "User" });
            }
                      
            return View();
        }

      
        public PartialViewResult DeleteCart(int Id)
        {
            List<OrderDetails> orderdetaillist = Session["cart"] as List<OrderDetails>;
            var i1 = cartlist.Find(product => product.ProductId == Id);
           
                orderdetaillist.Remove(i1);
           



            //if (Session["username"] != null)
            //{
            //    getName = Session["username"].ToString();
            //}

            //ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();
            //List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

            //user = userList.FirstOrDefault(x => x.UserName == getName);

            //ShoppingMvc.Models.OrderDetails orderdetail = new ShoppingMvc.Models.OrderDetails();
            //List<ShoppingMvc.Models.OrderDetails> orderdetailList = orderdetailBL.GetAllOrderdetail();

            //int OrderId=orderBL.GetOrderId(Id,user.Id);
            //orderdetailBL.DeleteCart(user.Id, Id);
            //orderBL.DeleteOrderCart(OrderId);
         
            return (GetCartItems());

        }
    }
}