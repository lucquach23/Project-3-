using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public  class SlideDao
    {
        OnlineShopDbContext db = null;
        public SlideDao()
        {
            db = new EF.OnlineShopDbContext();
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public List<Slide> ListSlideRight()
        {
            return db.Slides.Where(x => x.Status == false).OrderByDescending(x => x.DisplayOrder).ToList();
        }
    }
}
