using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMvc.Models;
using BussinessLayer;
using System.Windows.Forms;

namespace ShoppingMvc.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        CategoryBL categoryBL = new CategoryBL();
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
            List<Catogery> categoryList = categoryBL.GetAllCategory();
            return View(categoryList);
        }
        public ActionResult Create()
        {

            Catogery category = new Catogery();
         
            return PartialView("AddEditCategory", category);

        }

        public ActionResult Edit(int id)
        {

            Catogery category = new Catogery();

            if (id != 0)
            {
                category = categoryBL.GetcategoryById(id);
            }

            return PartialView("AddEditCategory", category);

        }

        [HttpPost]
        public ActionResult Create(ShoppingMvc.Models.Catogery category)
        {
            try
            {
                if (category.Id != 0)
                {
                    int a = categoryBL.UpdateCategory(category);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been update successfully";
                        TempData["Type"] = "success";
                    }
                }
                else
                {
                    int a = categoryBL.SaveCategory(category);
                    if (a == 1)
                    {
                        TempData["Status"] = "Records has been added successfully";
                        TempData["Type"] = "success";
                       
                    }
                }

            }
            catch(Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

    }
}