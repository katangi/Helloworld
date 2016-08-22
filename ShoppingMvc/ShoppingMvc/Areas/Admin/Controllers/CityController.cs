using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;
using ShoppingMvc.Models;
using System.Windows.Forms;
using PagedList;
namespace ShoppingMvc.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        // GET: Admin/City
        StateBL stateBL = new StateBL();
        CityBL cityBL = new CityBL();
        public ActionResult Index(string Search_Data, string Sorting_Order, string Filter_Value, int? Page_No)
        {

            ViewBag.Status = TempData["Status"];
            ViewBag.Type = TempData["Type"];
            if (Search_Data != null)
            {
                //var product = (from N in productList where N.Name.StartsWith(Search_Data) select N).ToList();
                //return View("UserIndex", product);

            }
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                {
                    List<ShoppingMvc.Models.City> cityList2 = cityBL.GetAllCity();
                  
                    var city2 = (from N in cityList2 where N.CityName.StartsWith(Search_Data) select N).ToList();
                }
            }


            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name" : "";

            ShoppingMvc.Models.City city = new ShoppingMvc.Models.City();
            List<ShoppingMvc.Models.City> cityList1 = cityBL.GetAllCity();
            var city1 = from cut in cityList1 select cut;

            if (Session["username"] != null)
            {
                string getName = Session["username"].ToString();
                ViewBag.userName = getName;
            }
            else
            {
                return RedirectToAction("Login", "User", new { area = "User" });
            }
                      
            switch (Sorting_Order)
            {
                case "Name":
                    city1 = city1.OrderByDescending(cut => cut.CityName);
                    break;
               
                
                default:
                    city1 = city1.OrderBy(cut => cut.CityName);
                    break;
            }
            List<City> cityList = cityBL.GetAllCity();
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(city1.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult Create()
        {

            ShoppingMvc.Models.City city = new ShoppingMvc.Models.City();
            List<State> StateList = stateBL.GetAllState();

            ViewBag.StateName = StateList;

            return PartialView("AddEditCity", city);

        }
        public ActionResult Edit(int id)
        {
                     
            City city = new City();
          
            if (id != 0)
            {
                city = cityBL.GetcityById(id);
                List<State> StateList = stateBL.GetAllState();
                var sList = StateList.Select(m => new SelectListItem() { Text = m.StateName, Value = m.Id.ToString() });
                ViewBag.MyList = sList;
            }

            return PartialView("AddEditCity", city);

        }


        [HttpPost]
        public ActionResult Create(ShoppingMvc.Models.City city)
        {
            try
            {
                if (city.Id != 0)
                {
                    int a = cityBL.UpdateCity(city);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been update successfully";
                        TempData["Type"] = "success";
                    }
                }
                else
                {
                    int a = cityBL.SaveCity(city);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been added successfully";
                        TempData["Type"] = "success";
                       
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return RedirectToAction("Index", "City", new { area = "Admin" });
        }
        [HttpPost]
        public ActionResult Delete(ShoppingMvc.Models.City city)
        {


            if (city.Id != 0)
            {

                cityBL.DeleteCity(city);

            }

            return RedirectToAction("Index", "City", new { area = "Admin" });

        }
    }
}