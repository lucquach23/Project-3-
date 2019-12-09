using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Luc_OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "xemct",
            url: "chi-tiet-don-hang/{idorder}",
            defaults: new { controller = "DHang", action = "ViewP", id = UrlParameter.Optional },
            namespaces: new[] { "Luc_OnlineShop.Areas.Admin.Controllers" }
        );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "Admin",
            url: "admin",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "Luc_OnlineShop.Areas.Admin.Controllers" }
        );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "dh",
            url: "don-hang",
            defaults: new { controller = "DH", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "Luc_OnlineShop.Areas.Admin.Controllers" }
        );
            routes.MapRoute(
             name: "Add Cart",
             url: "them-gio-hang",
             defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
             namespaces: new[] { "Luc_OnlineShop.Controllers" }
         );
            routes.MapRoute(
            name: "Add Cartth",
            url: "chi-tiet/them-hang",
            defaults: new { controller = "Detail", action = "AddItem", id = UrlParameter.Optional },
            namespaces: new[] { "Luc_OnlineShop.Controllers" }
        );
            routes.MapRoute(
            name: "Cart",
            url: "gio-hang",
            defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "Luc_OnlineShop.Controllers" }
        );
            routes.MapRoute(
           name: "Cartct",
           url: "chi-tiet/gio-hang",
           defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "Luc_OnlineShop.Controllers" }
       );
            routes.MapRoute(
           name: "Hoàn thành",
           url: "hoan-thanh",
           defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
           namespaces: new[] { "Luc_OnlineShop.Controllers" }
       );
            routes.MapRoute(
            name: "Payment",
            url: "thanh-toan",
            defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
            namespaces: new[] { "Luc_OnlineShop.Controllers" }
        );
            routes.MapRoute(
            name: "Product Detail",
            url: "chi-tiet/{MetaTitle}-{id}",
            defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
            namespaces: new[] { "Luc_OnlineShop.Controllers" }
        );
            routes.MapRoute(
           name: "Giới thiệu",
           url: "gioi-thieu",
           defaults: new { controller = "GioiThieu", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "Luc_OnlineShop.Controllers" }
       );
            routes.MapRoute(
          name: "Liên hệ",
          url: "lien-he",
          defaults: new { controller = "LienHe", action = "Index", id = UrlParameter.Optional },
          namespaces: new[] { "Luc_OnlineShop.Controllers" }
      );
            routes.MapRoute(
         name: "Tin tức",
         url: "tin-tuc",
         defaults: new { controller = "TinTuc", action = "Index", id = UrlParameter.Optional },
         namespaces: new[] { "Luc_OnlineShop.Controllers" }
     );
            routes.MapRoute(
        name: "Register",
        url: "dang-ki",
        defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
        namespaces: new[] { "Luc_OnlineShop.Controllers" }
    );
            routes.MapRoute(
         name: "Sản phẩm",
         url: "san-pham",
         defaults: new { controller = "Product", action = "LoadAll", id = UrlParameter.Optional },
         namespaces: new[] { "Luc_OnlineShop.Controllers" }
     );
            routes.MapRoute(
         name: "Lịch sử",
         url: "lich-su",
         defaults: new { controller = "LichSu", action = "Index", id = UrlParameter.Optional },
         namespaces: new[] { "Luc_OnlineShop.Controllers" }
     );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Luc_OnlineShop.Controllers" }
           );



        }
    }
}
