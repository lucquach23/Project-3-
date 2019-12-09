using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModal;
using Model.Dao;
using PagedList;

namespace Model.Dao
{
  public  class DHDao
    {
        OnlineShopDbContext db = null;
        public DHDao ()
        {
            db = new EF.OnlineShopDbContext();
        }
        public bool Update(DonHang dh)
        {
            try
            {
                var ncc = db.DonHangs.Find(dh.CustomerID);
                ncc.tenKH = dh.tenKH;
                ncc.Sdt = dh.Sdt;
                ncc.DiaChi = dh.DiaChi;
                ncc.Email = dh.Email;
                ncc.NgayGuiDon = dh.NgayGuiDon;
                ncc.Status = dh.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public DonHang ViewDetail(int id)
        {
            return db.DonHangs.Find(id);
        }
        public IEnumerable<DonHang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<DonHang> model = db.DonHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.tenKH.Contains(searchString));
            }
            return model.OrderByDescending(x => x.NgayGuiDon).ToPagedList(page, pageSize);
        }

        private void ToPagedList(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public NCC GetByID(string Tenncc)
        {
            return db.NCCs.SingleOrDefault(x => x.Name == Tenncc);
        }
        public bool Delete(int id)
        {
            try
            {
                var ncc = db.DonHangs.Find(id);
                db.DonHangs.Remove(ncc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



        //public IEnumerable<DonHangViewModal> get_View()
        //{
        //    var model = from kh in db.KhachHangs
        //                join or in db.Orders on kh.ID equals or.CustomerID
        //                join orde in db.OrderDetails on or.ID equals orde.OrderID
        //                join p in db.Products on orde.ProductID equals p.ID
        //                where orde.OrderID == or.ID && orde.ProductID == p.ID
        //                select new DonHangViewModal()
        //                {
        //                    customer = kh,
        //                    order = or,
        //                    orderdetail = orde,
        //                    product = p,
        //                    //tongTien = TongtienByID(orde.OrderID)
        //                };
        //    return model;
        //}
    }
}
