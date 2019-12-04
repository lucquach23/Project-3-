using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   public class KhachHangDao
    {
        OnlineShopDbContext db = null;
        public KhachHangDao()
        {
            db = new EF.OnlineShopDbContext();
        }
        public long Insert(KhachHang entity)
        {
            db.KhachHangs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(KhachHang entity)
        {
            try
            {
                var user = db.KhachHangs.Find(entity.ID);
                user.TenKH = entity.TenKH;               
                user.Tuoi = entity.Tuoi;               
                user.GioiTinh = entity.GioiTinh;
                user.DiaChi = entity.DiaChi;
                user.Email = entity.Email;
                user.Sdt = entity.Sdt;               
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public KhachHang ViewDetail(int id)
        {
            return db.KhachHangs.Find(id);
        }
        public IEnumerable<KhachHang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<KhachHang> model = db.KhachHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKH.Contains(searchString));
            }
            return model.OrderByDescending(x => x.TenKH).ToPagedList(page, pageSize);
        }

        private void ToPagedList(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public KhachHang GetByID(string tenkh)
        {
            return db.KhachHangs.SingleOrDefault(x => x.TenKH == tenkh);
        }
        public bool Delete(int id)
        {
            try
            {
                var kh = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(kh);
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
