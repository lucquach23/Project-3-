using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public  class CategoryDao
    {
        OnlineShopDbContext db = null;
        public CategoryDao()
        {
            db = new EF.OnlineShopDbContext();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
