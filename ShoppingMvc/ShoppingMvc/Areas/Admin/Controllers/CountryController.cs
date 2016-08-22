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
    public class CountryController : Controller
    {
        // GET: Admin/Country
        CountryBL countryBL = new CountryBL();
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
            List<Country> countryList = countryBL.GetAllCountry();
            return View(countryList);
        }

        public ActionResult Create()
        {

            Country country = new Country();

            return PartialView("AddEditCountry", country);

        }

        public ActionResult Edit(int id)
        {

            Country country = new Country();

            if (id != 0)
            {
                country = countryBL.GetCountryById(id);
            }

            return PartialView("AddEditCountry", country);

        }

        [HttpPost]
        public ActionResult Create(ShoppingMvc.Models.Country country)
        {
            try
            {
                if (country.Id != 0)
                {
                    int a = countryBL.UpdateCountry(country);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been update successfully";
                        TempData["Type"] = "success";
                    }
                }
                else
                {
                    int a = countryBL.SaveCountry(country);
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
            return RedirectToAction("Index", "Country", new { area = "Admin" });
        }
        [HttpPost]
        public ActionResult Delete(ShoppingMvc.Models.Country country)
        {


            if (country.Id != 0)
            {

                countryBL.DeleteCountry(country);

            }

            return RedirectToAction("Index", "Country", new { area = "Admin" });

        }
    }
}