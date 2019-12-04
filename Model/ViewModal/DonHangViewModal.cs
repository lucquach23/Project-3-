using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModal
{
   public class DonHangViewModal
    {
        public KhachHang customer { get; set; }
        public Order order { get; set; }
        public OrderDetail orderdetail { get; set; }
        public Product product { get; set; }
        public decimal tongTien
        {
            get; set;   
        }
    }
}
