using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModal;
using PagedList;

namespace Model.Dao
{
 public   class DonHangDao
    {
        OnlineShopDbContext db = null;
        public DonHangDao()
        {
            db = new EF.OnlineShopDbContext();
        }
        public bool Insert(DonHang dh)
        {
            try
            {
                db.DonHangs.Add(dh);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void InsertDH(DonHang dh)
        {
            db.DonHangs.Add(dh);
            db.SaveChanges();
        }


        public IEnumerable<DonHangViewModal> get_View()
        {
            var model = from kh in db.KhachHangs
                        join or in db.Orders on kh.ID equals or.CustomerID
                        join orde in db.OrderDetails on or.ID equals orde.OrderID
                        join p in db.Products on orde.ProductID equals p.ID
                        select new DonHangViewModal()
                        {
                            customer = kh,
                            order = or,
                            orderdetail = orde,
                            product = p,
                            //tongTien = TongtienByID(orde.OrderID)
                        };
            return model;
        }
        //public decimal TongtienByID(long id)
        //{
        //    decimal tt = 0;
        //    foreach(var i in db.OrderDetails.Where(x=>x.OrderID==id))
        //    {
        //        tt += i.Price * i.Quantity;
        //    }
        //    return tt;
        //}
        public IEnumerable<DonHangViewModal> listDonHangPage(string searchString, int page , int pageSize)
        {
            var model = get_View();
            if(!string.IsNullOrEmpty(searchString))
            {
                model=model.Where(x=>x.customer.TenKH.Contains(searchString));
            }
            return model.OrderBy(x => x.order.CreateDate).ToPagedList(page, pageSize);
        }
    }
}
