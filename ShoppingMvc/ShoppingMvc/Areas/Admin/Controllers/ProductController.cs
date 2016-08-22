using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;
using ShoppingMvc.Models;
using System.Web.UI.WebControls;

namespace ShoppingMvc.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        int a;
        // GET: Admin/Product
        ProductBL productBL = new ProductBL();
        OrderDetailsBL orderBL = new OrderDetailsBL();
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
            List<ShoppingMvc.Models.Product> productList = productBL.GetAllProduct();
            return View("Index", productList);
        }
        public ActionResult Create()
        {

            ShoppingMvc.Models.Product product = new ShoppingMvc.Models.Product();
            List<ShoppingMvc.Models.Catogery> CategoryList = categoryBL.GetAllCategory();

            ViewBag.CategorytName = CategoryList;

            return PartialView("AddEditProduct", product);

        }

        public ActionResult Edit(int id)
        {

            ShoppingMvc.Models.Product product = new ShoppingMvc.Models.Product();

            if (id != 0)
            {
                product = productBL.GetProductById(id);
                List<Catogery> CategoryList = categoryBL.GetAllCategory();
                var cList = CategoryList.Select(m => new SelectListItem() { Text = m.CategoryName, Value = m.Id.ToString() });
              
                ViewBag.MyList = cList;
            }

            return PartialView("AddEditProduct", product);

        }
        [HttpPost]
        public ActionResult Delete(ShoppingMvc.Models.Product product)
        {


            if (product.Id != 0)
            {
               
                productBL.DeleteProduct(product);

            }

            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }

        [HttpPost]
        public ActionResult Create(ShoppingMvc.Models.Product product, HttpPostedFileBase file)
        {
            
                try
                {
                    if (product.Id != 0)
                    {

                        if (file != null)
                        {
                        
                            string ImageName = System.IO.Path.GetFileName(file.FileName);
                            string physicalPath = Server.MapPath("~/Image/" + ImageName);
                                                    
                            file.SaveAs(physicalPath);
                            product.Image = ImageName;

                        }
                        a = productBL.UpdateProduct(product);
                        if (a == 1)
                        {
                            TempData["Status"] = "Records has been update successfully";
                            TempData["Type"] = "success";

                        }

                    }

                    else
                    {

                    if (file != null)
                    {
                         string ImageName = System.IO.Path.GetFileName(file.FileName);
                            //var extention = ImageName.Split('.');

                            //if (extention[1] != "jpg" && extention[1] != "jpeg" && extention[1] != "gif" && extention[1] != "png")
                            //{
                            //    return Json("Only image formats (jpg, png, gif) are accepted ", JsonRequestBehavior.AllowGet);
                            //}
                            string physicalPath = Server.MapPath("~/Image/" + ImageName);

                            file.SaveAs(physicalPath);
                            product.Image = ImageName;


                        }
                        a = productBL.SaveProduct(product);
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
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Please upload valid format");
            //}
          
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}