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
    public class UserController : Controller
    {
        // GET: User
       

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                if(dao.checkUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                    //return View("Register");
                }
                else if(dao.checkEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                    //return View("Register");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Name = model.Name;
                    user.Password = model.Password;
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.CreateDate = DateTime.Now;
                    user.Status = false;
                   var result= dao.Insert(user);
                    if(result>0)
                    {
                        
                        ViewBag.Success = "Đăng kí thành công";
                        model = new Models.RegisterModel();
                        //return RedirectToAction("Register", "User");          
                     }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công");
                    }
                   
                }
            }
            return View(model);
        }
       
    }
}