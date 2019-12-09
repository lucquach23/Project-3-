using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModal
{
  public class DHViewModel
    {
        public DonHang donhang { get; set; }
        public OrderDetail ctdh { get; set; }
        public Product sp { get; set; }
    }
}
