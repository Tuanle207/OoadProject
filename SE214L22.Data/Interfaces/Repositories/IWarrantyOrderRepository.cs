using SE214L22.Data.Entity.AppCustomer;
using System.Collections.Generic;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IWarrantyOrderRepository : IBaseRepository<WarrantyOrder>
    {
        IEnumerable<WarrantyOrder> GetAllWithStatusFilter(List<WarrantyOrderStatus> filter);
        int GetNumberOfWarrantyOrderByInvoiceIdAndProductId(int invoiceId, int productId);
    }
}