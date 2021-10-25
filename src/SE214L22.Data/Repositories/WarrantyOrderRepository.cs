using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SE214L22.Data.Repositories
{
    public class WarrantyOrderRepository : BaseRepository<WarrantyOrder>, IWarrantyOrderRepository
    {
        public IEnumerable<WarrantyOrder> GetAllWithStatusFilter(List<WarrantyOrderStatus> filter)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.WarrantyOrders.AsQueryable();
                query = query.Where(wo => filter.Contains((WarrantyOrderStatus)(wo.Status)));
                query = query.Include(wo => wo.Customer);
                query = query.Include(wo => wo.Product);
                return query.ToList();
            }
        }

        public int GetNumberOfWarrantyOrderByInvoiceIdAndProductId(int invoiceId, int productId)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.WarrantyOrders
                    .Where(ip => ip.InvoiceId == invoiceId)
                    .Where(ip => ip.ProductId == productId);

                return query.Count();
            }
        }
    }
}
