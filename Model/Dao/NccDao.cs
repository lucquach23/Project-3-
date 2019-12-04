using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public  class NccDao
    {
        OnlineShopDbContext db = null;
        public NccDao()
        {
            db = new EF.OnlineShopDbContext();
        }
        public int Insert(NCC entity)
        {
            db.NCCs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(NCC entity)
        {
            try
            {
                var ncc = db.NCCs.Find(entity.ID);
                ncc.Name = entity.Name;
                ncc.Address = entity.Address;
                ncc.Email = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public NCC ViewDetail(int id)
        {
            return db.NCCs.Find(id);
        }
        public IEnumerable<NCC> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<NCC> model = db.NCCs;
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

        public NCC GetByID(string Tenncc)
        {
            return db.NCCs.SingleOrDefault(x => x.Name == Tenncc);
        }
        public bool Delete(int id)
        {
            try
            {
                var ncc = db.NCCs.Find(id);
                db.NCCs.Remove(ncc);
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
