using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luc_OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Category(long cateId)
        {
            var cate = new CategoryDao().ViewDetail(cateId);
            return View(cate);
        }
        public ActionResult Detail(long id)
        {
           
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
        [ChildActionOnly]
        public ActionResult RelateP()
        { 
            var listRelate = new ProductDao().listRelate(6);
            return PartialView(listRelate);
        }
        public ActionResult LoadAll(string searchString, int page = 1, int pageSize = 12)
        {
            var model = new ProductDao().ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
    }
}