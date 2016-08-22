using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ShoppingMvc.Models;
namespace BussinessLayer
{
  public class CategoryBL
    {
        CategoryDL categoryDL = new CategoryDL();
        public int SaveCategory(Catogery category)
        {
            int a = categoryDL.SaveCategory(category);
            return a;
        } 
        public List<Catogery>GetAllCategory()
        {
            List<Catogery> categoryList = categoryDL.GetAllCategory();
            return categoryList;
        }

        public Catogery GetcategoryById(int Id)
        {
            Catogery category = categoryDL.GetCategoryById(Id);
            return category;
        }

        public int UpdateCategory(Catogery category)
        {
            int a = categoryDL.UpdateCategory(category);
            return a;
        }
    }
}
