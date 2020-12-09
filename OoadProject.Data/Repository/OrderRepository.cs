using OoadProject.Data.Entity.AppProduct;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace OoadProject.Data.Repository
{
    public class OrderRepository
    {
        public IEnumerable<Order> GetOrders(List<OrderStatus> status = null, int? limit = null)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.Orders.AsQueryable();

                if (status != null)
                {
                    query = query.Where(o => status.Contains((OrderStatus)o.Status));
                }
                if (limit != null)
                {
                    query = query.Take((int)limit);
                }

                query = query.Include(o => o.CreationUser).Include(o => o.Provider);
                var orders = query.ToList();

                return orders;
            }
        }
    }
}
