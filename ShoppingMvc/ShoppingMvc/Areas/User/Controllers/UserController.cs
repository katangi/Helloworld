using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMvc.Models;
using BussinessLayer;
using System.Data;
using System.Windows.Forms;



namespace ShoppingMvc.Areas.User.Controllers
{
    public class UserController : Controller
    {
        // GET: User/User
        CountryBL countryBL = new CountryBL();
      
        UserBL userBL = new UserBL();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Create()
        {

            ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();
            List<Country> CountryList = countryBL.GetAllCountry();

            ViewBag.CountryName = CountryList;

             return View("Registration", user);

        }
        public ActionResult MyProfile()
        {

            ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();
            List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();
            string getName = Session["username"].ToString();
            user = userList.FirstOrDefault(x => x.UserName == getName);
            int id = user.Id;
            var mydetail = userBL.MyprofileById(id);
            return View("MyProfile", mydetail);

        }
        [HttpPost]
        public ActionResult Create(ShoppingMvc.Models.User user)
        {
           
            int a = userBL.SaveUser(user);
            List<ShoppingMvc.Models.User> UesrList = userBL.GetAllUser();


            string Address = user.UserAddress;

            if (a == 1)
            {

                ViewBag.Success = "Record has been add successfully";
            }
          
            return RedirectToAction("Login", "User",new {area="User" });
        }
        public JsonResult StateList(int Id)
        {
            var stateList = new StateBL().GetStateByCountryId(Id);
            var stateData = stateList.Select(m => new SelectListItem()
            {
                Text = m.StateName,
                Value = m.Id.ToString(),
               
            });
             
            if (stateList != null)
            {
               return Json(stateData, JsonRequestBehavior.AllowGet);
            }
            return null;           
            
        }

        public JsonResult Citylist(int Id)
        {
            var cityList = new CityBL().GetCityByStateId(Id);
            var stateData = cityList.Select(m => new SelectListItem()
            {
                Text = m.CityName,
                Value = m.Id.ToString(),
            });
            if (cityList != null)
            {
                return Json(stateData, JsonRequestBehavior.AllowGet);
            }
            return null;

        }

        public JsonResult CheckUserEmailExists(string Email)
        {

            //Check in database that particular Email is exist or not

            ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();

            List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

            user = userList.FirstOrDefault(x => x.Email == Email);


            if (user != null)
            {

                return Json("Already in use", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Login()
        {

            ShoppingMvc.Models.UserLogin user = new ShoppingMvc.Models.UserLogin();
            return View("Login",user);

        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            if(Session["username"]!=null)
            {
                Session["username"]= null;
                Session.Remove("username");
                Session.Remove("cart");
                Session.Remove("count");
                //string a = Session["username"].ToString();
            }
          

            ShoppingMvc.Models.UserLogin user = new ShoppingMvc.Models.UserLogin();
            return View("Login", user);

        }
        [HttpPost]
        public ActionResult Login(string Email,String Password,UserLogin model)
        {
            UserLogin user = new UserLogin();
          
            {
                user.Email = Email;
                user.Password = Password;
                };

            List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

           var name = userList.FirstOrDefault(x => x.Email == Email);
            if (name != null)
            {
                Session["username"] = name.UserName;
            }
            DataTable dt = new UserBL().GetLoginDetail(user);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (Email == "Admin@wwindia.com" && Password == "123")
                {
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
                else
                {
                    if (Session["productId"] == null)
                    {
                        return RedirectToAction("UserIndex", "Product", new { area = "Product" });

                    }
                    else {
                        var Id = Session["productId"].ToString();

                        return RedirectToAction("ProductDetail", "Product", new { area = "Product", id = Id });
                    }
                }
            }
            else
            {
                // ViewData["Error"] = "Wrong Email and Password";
                ViewBag.Error = "Wrong Email and Password";
                return View(model);
            }

          //  return RedirectToAction("Login", "User", new { area = "User" });

        }
    }
}