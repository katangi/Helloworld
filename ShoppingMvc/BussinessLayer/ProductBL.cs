using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingMvc.Models;
using DataAccessLayer;

namespace BussinessLayer
{
   
    public class ProductBL
    {
        ProductDL productDL = new ProductDL();
        public List<Product>GetAllProduct()
        {
            List<Product> productList = productDL.GetAllProduct();
            return productList;
        }
        public int SaveProduct(Product product)
        {
            int a = productDL.SaveProduct(product);
            return a;
              
        }
        public int UpdateProduct(Product product)
        {
            int a = productDL.UpdateProduct(product);
            return a;

        }
        public int DeleteProduct(Product product)
        {
            int a = productDL.DeleteProduct(product);
            return a;
        }

        public Product GetProductById(int id)
        {
            Product product = productDL.GetProdyctById(id);
            return product;
        }
    }
}
