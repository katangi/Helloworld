﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
            // defaults: new { controller = "Product", action = "ProductIndex", id = UrlParameter.Optional }).DataTokens.Add("area", "Product");
            // defaults: new { controller = "Product", action = "ProductIndex", id = UrlParameter.Optional }).DataTokens.Add("area", "Product");
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}