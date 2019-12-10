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

        //public List<ViewModelProduct> ViewModelProduct(long idorder)
        //{
        //    var model = from spp in db.Products
        //                join orde in db.OrderDetails
        //                on spp.ID equals orde.ProductID

        //                where orde.OrderID == idorder
        //                select new ViewModelProduct()
        //                {
        //                    ordetail=orde,
        //                    sp = spp


        //                };
        //    return model.ToList();
        //}

        public List<ViewModelProduct> getAllDetai()
        {
            var model = from spp in db.Products
                        join orde in db.OrderDetails
                        on spp.ID equals orde.ProductID


                        select new ViewModelProduct()
                        {
                            ordetail = orde,
                            sp = spp


                        };
            return model.ToList();
        }

        public bool ChangeStatus(long id)
        {
            var dh = db.DonHangs.Find(id);
            dh.Status = !dh.Status;
            db.SaveChanges();
            return !dh.Status;
        }

        public List<Product> get_View(long idorder)
        {
            var model = from or in db.Orders
                        join orde in db.OrderDetails
                        on or.ID equals orde.OrderID

                        where or.ID == idorder
                        select new Product()
                        {
                            
                            ID = orde.ProductID,
                           
                            //tongTien = TongtienByID(orde.OrderID)
                        };
            return model.ToList();
        }
        public List<Model.ViewModal.DHViewModel> getView(long idorder)
        {
            var model = from or in db.Orders
                        join orde in db.OrderDetails
                        on or.ID equals orde.OrderID
                        join p in db.Products on orde.ProductID equals p.ID
                        where or.ID == idorder && orde.ProductID==p.ID
                        select new DHViewModel()
                        {
                            sp = p
                        };
            return model.ToList();
        }
        public Product get1_View(long idProduct)
        {
            return db.Products.Find(idProduct);
            //var modell = from or in db.Orders
            //            join orde in db.OrderDetails
            //            on or.ID equals orde.OrderID

            //            where or.ID == idorder
            //            select new Product()
            //            {
            //                ID = orde.ProductID,

            //                //tongTien = TongtienByID(orde.OrderID)
            //            };
            //return modell.OrderByDescending(x=>x.ID);
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
        //public IEnumerable<DonHangViewModal> listDonHangPage(string searchString, int page , int pageSize)
        //{
        //    var model = get_View();
        //    if(!string.IsNullOrEmpty(searchString))
        //    {
        //        model=model.Where(x=>x.customer.TenKH.Contains(searchString));
        //    }
        //    return model.OrderBy(x => x.order.CreateDate).ToPagedList(page, pageSize);
        //}
    }
}
