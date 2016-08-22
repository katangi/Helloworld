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
    public class StateController : Controller
    {
        // GET: Admin/State
        StateBL stateBL = new StateBL();
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
            List<State> stateList = stateBL.GetAllState();
          
            return View(stateList);
        }
        [HttpPost]
        public ActionResult Delete(ShoppingMvc.Models.State state)
        {


            if (state.Id != 0)
            {

                stateBL.DeleteState(state);

            }

            return RedirectToAction("Index", "State", new { area = "Admin" });

        }
        public ActionResult Create()
        {

            ShoppingMvc.Models.State state = new ShoppingMvc.Models.State();
            List<Country> CountryList = countryBL.GetAllCountry();

            ViewBag.CountryName = CountryList;

            return PartialView("AddEditState", state);

        }

        public ActionResult Edit(int id)
        {

            State state = new State();
            if (id != 0)
            {
                state = stateBL.GetStateById(id);

                //SelectListItem item;
                //List<SelectListItem> myList = new List<SelectListItem>();
                //item = new SelectListItem();
                //item.Text = state.CountryName;
                //item.Value = state.CountryId.ToString();
                List<Country> CountryList = countryBL.GetAllCountry();
                var cList = CountryList.Select(m => new SelectListItem() { Text = m.CountryName, Value = m.Id.ToString() });
                //myList.Add(item);
                 ViewBag.MyList = cList;
              }
            return PartialView("AddEditState", state);

        }


        [HttpPost]
        public ActionResult Create(ShoppingMvc.Models.State state)
        {
            try
            {
                if (state.Id != 0)
                {
                    int a = stateBL.UpdateState(state);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been update successfully";
                        TempData["Type"] = "success";
                    }
                }
                else
                {
                    int a = stateBL.SaveState(state);
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
            return RedirectToAction("Index", "State", new { area = "Admin" });
        }
    }
}