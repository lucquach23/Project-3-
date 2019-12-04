using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new EF.OnlineShopDbContext();
        }

       
       








        /// <summary>
        /// sản phẩm mới với giá lớn hơn 15tr
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.Where(x => x.Price > 15000000).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }


        /// <summary>
        /// lấy n (top) bản ghi hiển thị lên sản phẩm nổi bật
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }


        /// <summary>
        /// lấy n (top) bản ghi với giá nhỏ hơn 15tr hiển thị lên chỗ sale
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> listSale(int top)
        {
            return db.Products.Where(x=>x.Price<15000000).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }


        /// <summary>
        /// tìm id sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        /// <summary>
        /// sản phẩm liên quan , hiển thị lên chỗ có thể bạn quan tâm
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> listRelate (int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }



        /// <summary>
        /// lấy tất bản ghi từ csdl để hiện lên trang sản phẩm
        /// </summary>
        /// <returns></returns>
        public List<Product> ShowAll()
        {
            return db.Products.OrderByDescending(x => x.ID).ToList();
        }


        /// <summary>
        /// phan trag dl
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Product> ListAllPaging(string searchString, int page = 1, int pageSize = 10)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
    }
}
