using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luc_OnlineShop.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // 
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new KhachHangDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KhachHang user)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
               
                long id = dao.Insert(user);

                if (id > 0)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {

                    ModelState.AddModelError("", "Thêm không thành công!");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(KhachHang user)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
              

                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {

                    ModelState.AddModelError("", "Cập nhật không thành công!");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var user = new KhachHangDao().ViewDetail(id);
            return View(user);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KhachHangDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}