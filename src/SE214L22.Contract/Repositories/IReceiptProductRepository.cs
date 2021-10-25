using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IReceiptProductRepository : IBaseRepository<ReceiptProduct>
    {
        IEnumerable<ReceiptProduct> GetAllByReceiptId(int id);
    }
}