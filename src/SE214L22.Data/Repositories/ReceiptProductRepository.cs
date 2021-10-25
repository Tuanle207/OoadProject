using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SE214L22.Data.Repositories
{
    public class ReceiptProductRepository : BaseRepository<ReceiptProduct>, IReceiptProductRepository
    {
        public IEnumerable<ReceiptProduct> GetAllByReceiptId(int id)
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.ReceiptProducts
                    .Where(rp => rp.ReceiptId == id)
                    .Include(rp => rp.Product)
                    .Include(rp => rp.Product.Category)
                    .ToList();
            }
        }
    }
}
