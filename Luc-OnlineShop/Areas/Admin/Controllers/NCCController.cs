using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luc_OnlineShop.Areas.Admin.Controllers
{
    public class NCCController : Controller
    {
      
            public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
            {
                var dao = new NccDao();
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
            public ActionResult Create(NCC ncc)
            {
                if (ModelState.IsValid)
                {
                    var dao = new NccDao();

                    long id = dao.Insert(ncc);

                    if (id > 0)
                    {
                        return RedirectToAction("Index", "NCC");
                    }
                    else
                    {

                        ModelState.AddModelError("", "Thêm không thành công!");
                    }
                }
                return View("Index");
            }

            [HttpPost]
            public ActionResult Edit(NCC ncc)
            {
                if (ModelState.IsValid)
                {
                    var dao = new NccDao();


                    var result = dao.Update(ncc);
                    if (result)
                    {
                        return RedirectToAction("Index", "NCC");
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
                var ncc = new NccDao().ViewDetail(id);
                return View(ncc);
            }

            [HttpDelete]
            public ActionResult Delete(int id)
            {
                new NccDao().Delete(id);
                return RedirectToAction("Index");
            }

        }
    
}