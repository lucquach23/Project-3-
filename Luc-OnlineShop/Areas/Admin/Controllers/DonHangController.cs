using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luc_OnlineShop.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        public ActionResult Index(string searchString, int page=1, int pageSize=10)
        {
            var dao = new DonHangDao();
            var model = dao.listDonHangPage(searchString,page ,pageSize);
            ViewBag.SearchString = searchString;
            //ViewBag.tt=dao.TongtienByID()
            return View(model);
        }
    }
}