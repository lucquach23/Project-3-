using Common;
using Luc_OnlineShop.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Luc_OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: CartItem
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
                return View(list);
        }
        public ActionResult AddItem(long productID,int quantity)
        {
            var cart = Session[CartSession];
            var product = new ProductDao().ViewDetail(productID);   
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x=>x.Product.ID==productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                    Session[CartSession] = list;
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }

            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);

                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if(jsonItem !=null)
                {
                    item.Quantity = jsonItem.Quantity;
                }      
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName,string mobie,string address,string email)
        {
            var dh = new DonHang();
                var order = new Order();
                var kh = new KhachHang();


                kh.TenKH = shipName;
            dh.tenKH = shipName;
                kh.Sdt = mobie;
            dh.Sdt = mobie;
                kh.DiaChi = address;
                kh.Email = email;
            dh.Email = email;
                new KhachHangDao().Insert(kh);
                order.CreateDate = DateTime.Now;
            dh.NgayGuiDon = order.CreateDate;
                order.ShipAddress = address;
                order.ShipMobie = mobie;
                order.ShipEmail = email;
                order.CustomerID = kh.ID;
            dh.CustomerID = kh.ID;
                try
                {

                    var id = new OrderDao().Insert(order);
                dh.OrderID = order.ID;
                    var cart = (List<CartItem>)Session[CartSession];
                    var detailDao = new OrderDetailDao();
                    decimal total = 0;
                    foreach (var item in cart)
                    {
                        var orderDetail = new OrderDetail();
                        orderDetail.ProductID = item.Product.ID;
                        orderDetail.OrderID = id;
                        orderDetail.Price = item.Product.Price.GetValueOrDefault(0);
                        orderDetail.Quantity = item.Quantity;
                        detailDao.Insert(orderDetail);

                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                    //total += (item.Product.Price * item.Quantity);
                    dh.TotalMoney = total;
                    }
                new DonHangDao().InsertDH(dh);

                    //string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/neworder.html"));
                    //content = content.Replace("{{CustomerName}}", shipName);
                    //content = content.Replace("{{Phone}}", mobie);
                    //content = content.Replace("{{Email}}", email);
                    //content = content.Replace("{{Address}}", address);
                    //content = content.Replace("{{Total}}", total.ToString("N0"));
                    //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                    //new MailHelper().SendMail(email, "Đơn hàng mới từ ASUS-Online", content);
                    //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ ASUS-Online", content);
                }
                catch (Exception)
                {
                    return Redirect("/loi-thanh-toan");
                }
                return Redirect("/hoan-thanh");
            }
         
            
        







        //public ActionResult Payment(string shipName, string mobie, string address, string email)
        //{
        //    var order = new Order();
        //    order.CreateDate = DateTime.Now;
        //    order.ShipAddress = address;
        //    order.ShipMobie = mobie;
        //    order.ShipEmail = email;
        //    try
        //    {
        //        var id = new OrderDao().Insert(order);
        //        var cart = (List<CartItem>)Session[CartSession];
        //        var detailDao = new OrderDetailDao();
        //        foreach (var item in cart)
        //        {
        //            var orderDetail = new OrderDetail();
        //            orderDetail.ProductID = item.Product.ID;
        //            orderDetail.OrderID = id;
        //            orderDetail.Price = item.Product.Price;
        //            orderDetail.Quantity = item.Quantity;
        //            detailDao.Insert(orderDetail);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Redirect("/loi-thanh-toan");
        //    }
        //    return Redirect("/hoan-thanh");
        //}
        public ActionResult Success()
        {
            return View();
        }
    }
}