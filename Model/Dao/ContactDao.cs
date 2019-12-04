using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public  class ContactDao
    {
        OnlineShopDbContext db = null;
        public ContactDao()
        {
            db = new EF.OnlineShopDbContext();
        }
        public Contact getInfContact()
        {
            return db.Contacts.SingleOrDefault(x => x.Status == true);
        }
    }
}
