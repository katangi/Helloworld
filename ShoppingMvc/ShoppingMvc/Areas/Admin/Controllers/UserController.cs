using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;
using ShoppingMvc.Models;
using System.Windows.Forms;
namespace ShoppingMvc.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        UserBL userBL = new UserBL();
        CountryBL countryBL = new CountryBL();
        StateBL stateBL = new StateBL();
        CityBL cityBL = new CityBL();
        public ActionResult Index()
        {

            ViewBag.Status = TempData["Status"];
            ViewBag.Type = TempData["Type"];
            if (Session["username"] != null)
            {
                string getName = Session["username"].ToString();
                ViewBag.userName = getName;
            }
            else
            {
                return RedirectToAction("Login", "User", new { area = "User" });
            }
            List<ShoppingMvc.Models.User> userlist = userBL.GetAllUser();
            return View(userlist);

        }

        public ActionResult Create()
        {

            ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();

            List<ShoppingMvc.Models.Country> CountryList = countryBL.GetAllCountry();

            ViewBag.CountryName = CountryList;

            return PartialView("AddEditUser", user);

        }

        public ActionResult Edit(int id)
        {

            ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();

            if (id != 0)
            {
                user = userBL.GetUserById(id);

                List<Country> CountryList = countryBL.GetAllCountry();
                var cList = CountryList.Select(m => new SelectListItem() { Text = m.CountryName, Value = m.Id.ToString() });
                ViewBag.CountryName = cList;

                List<State> StateList = stateBL.GetAllState();
                var sList = StateList.Select(m => new SelectListItem() { Text = m.StateName, Value = m.Id.ToString() });

                ViewBag.StateName = sList;

                List<City> CityList = cityBL.GetAllCity();
                var ctList = CityList.Select(m => new SelectListItem() { Text = m.CityName, Value = m.Id.ToString() });

                ViewBag.CityName = ctList;
            }

            return PartialView("AddEditUser", user);

        }
        [HttpPost]
        public ActionResult Delete(ShoppingMvc.Models.User user)
        {


            if (user.Id != 0)
            {
                user.IsActive = false;

                userBL.DeleteUser(user);

            }

            return RedirectToAction("Index", "User", new { area = "Admin" });

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


        public JsonResult CheckUserEmailExists( string Email, int Id)
        {

            //Check in database that particular Email is exist or not

            ShoppingMvc.Models.User user = new ShoppingMvc.Models.User();

            List<ShoppingMvc.Models.User> userList = userBL.GetAllUser();

            user = userList.FirstOrDefault(x => x.Email == Email);

            if (Id == 0)
            {
                if (user == null )
                  
                    return Json(true, JsonRequestBehavior.AllowGet);
                else
                    return Json(false, JsonRequestBehavior.AllowGet);               

            }
            else
            {
                if (user == null || user.Id == Id )
                    return Json(true, JsonRequestBehavior.AllowGet);
                else                
                    return Json(false, JsonRequestBehavior.AllowGet);              
                               

            }

        }

        [HttpPost]
        public ActionResult Create(ShoppingMvc.Models.User user)
        {
            
            try
            {
                if (user.Id != 0)
                {

                    int a = userBL.UpdateUser(user);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been update successfully";
                        TempData["Type"] = "success";
                    }

                }
                else
                {

                    int a = userBL.SaveUser(user);
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
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
    }
}