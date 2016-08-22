using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ShoppingMvc.Areas.Product.Models;


namespace ShoppingMvc.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
            : base("DatabaseContext")
        {
            Database.SetInitializer<DatabaseContext>(null);

        }
        //public DbSet<User> User { get; set; }
        //public DbSet<City> City { get; set; }
        //public DbSet<Product> Product { get; set; }

        //public DbSet<Catogery> Catogery { get; set; }
    }
}