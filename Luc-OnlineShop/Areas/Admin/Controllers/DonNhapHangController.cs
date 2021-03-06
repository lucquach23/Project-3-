﻿using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luc_OnlineShop.Areas.Admin.Controllers
{
    public class DonNhapHangController : Controller
    {

        public ActionResult Index(string searchString, int page = 1, int pageSize = 12)
        {
            var dao = new SPDao();
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
        public ActionResult Create(Product sp)
        {
            if (ModelState.IsValid)
            {
                var dao = new SPDao();
                sp.MetaTitle = dao.CreateMetaTile(sp.Name);
                long id = dao.Insert(sp);

                if (id > 0)
                {
                    return RedirectToAction("Index", "SP");
                }
                else
                {

                    ModelState.AddModelError("", "Thêm không thành công!");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Product sp)
        {
            if (ModelState.IsValid)
            {
                var dao = new SPDao();


                var result = dao.Update(sp);
                if (result)
                {
                    return RedirectToAction("Index", "SP");
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
            var ncc = new SPDao().ViewDetail(id);
            return View(ncc);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SPDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}