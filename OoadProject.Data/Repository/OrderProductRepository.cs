using OoadProject.Data.Entity.AppProduct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class OrderProductRepository : BaseRepository<OrderProduct>
    {
        public IEnumerable<OrderProduct> GetOrderProductsByOrderId(int id)
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.OrderProducts
                    .Where(op => op.OrderId == id)
                    .Include(op => op.Product)
                    .Include(op => op.Product.Category)
                    .ToList();
            }
        }
    }
}
