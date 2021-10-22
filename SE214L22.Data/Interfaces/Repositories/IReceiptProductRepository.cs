using SE214L22.Data.Entity.AppProduct;
using System.Collections.Generic;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IReceiptProductRepository : IBaseRepository<ReceiptProduct>
    {
        IEnumerable<ReceiptProduct> GetAllByReceiptId(int id);
    }
}