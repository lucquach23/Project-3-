using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
 public   class SPDao
    {
        OnlineShopDbContext db = null;
        public SPDao()
        {
            db = new EF.OnlineShopDbContext();
        }
        public long Insert(Product sp)
        {
            db.Products.Add(sp);
            db.SaveChanges();
            return sp.ID;
        }
        public bool Update(Product entity)
        {
            try
            {
                var sp = db.Products.Find(entity.ID);
                sp.Name = entity.Name;
                sp.Code = entity.Code;
                sp.Image = entity.Image;
                sp.Price = entity.Price;
                sp.PromotionPrice = entity.PromotionPrice;
                sp.CreateBy = entity.CreateBy;
                sp.Processor = entity.Processor;
                sp.OperatingSystem = entity.OperatingSystem;
                sp.Memory = entity.Memory;
                sp.Screen = entity.Screen;
                sp.Graphics = entity.Graphics;
                sp.Storage = entity.Storage;
                sp.Keyboard = entity.Keyboard;
                sp.MemoryCardReader = entity.MemoryCardReader;
                sp.WebCam = entity.WebCam;
                sp.Display = entity.Display;
                sp.Sound = entity.Sound;
                sp.Pin = entity.Pin;
                sp.Adapter = entity.Adapter;
                sp.Size = entity.Size;
                sp.Mass = entity.Mass;
                var flag = db.SaveChanges();
                
                return true;


                //var sp = db.Products.Find(entity.ID);
                //sp.Name = entity.Name;
                //sp.Code = entity.Code;
                //sp.Image = entity.Image;
                //sp.Price = entity.Price;
                //sp.PromotionPrice = entity.PromotionPrice;
                //sp.Status = entity.Status;
                //db.SaveChanges();
                //return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }

        private void ToPagedList(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Product GetByID(string Tensp)
        {
            return db.Products.SingleOrDefault(x => x.Name == Tensp);
        }
        public bool Delete(int id)
        {
            try
            {
                var sp = db.Products.Find(id);
                db.Products.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
