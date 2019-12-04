using Luc_OnlineShop.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luc_OnlineShop.Controllers
{
    public class HomeController : Controller
    {
      
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.slideList = new SlideDao().ListAll();
            ViewBag.slideR = new SlideDao().ListSlideRight();

            ProductDao prdao = new ProductDao();

           
            ViewBag.listNewProduct =prdao.ListNewProduct(3);
            ViewBag.listSaleProduct = prdao.listSale(3);
            List<Product> l = prdao.ListFeatureProduct(6);

            return View(l);
        }




        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupID(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupID(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
           
            return PartialView(list);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footer = new FooterDao().GetFooter();
            return PartialView(footer);
        }
    }
}