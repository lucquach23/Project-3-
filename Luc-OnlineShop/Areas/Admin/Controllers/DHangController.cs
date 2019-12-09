using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace Luc_OnlineShop.Areas.Admin.Controllers
{
    public class DHangController : Controller
    {
        // GET: Admin/DHang
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var model = new DHDao().ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.showDetail = new DonHangDao().getAllDetai();
            return View(model);
        }
        //public ActionResult ViewP(long idorder)
        //{
        //    var model = new DonHangDao().ViewModelProduct(idorder);
        //    return View(model);
        //}
    }
}