using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IWarrantyOrderRepository : IBaseRepository<WarrantyOrder>
    {
        IEnumerable<WarrantyOrder> GetAllWithStatusFilter(List<WarrantyOrderStatus> filter);
        int GetNumberOfWarrantyOrderByInvoiceIdAndProductId(int invoiceId, int productId);
    }
}