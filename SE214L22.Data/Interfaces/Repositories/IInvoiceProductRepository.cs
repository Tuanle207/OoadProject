using SE214L22.Data.Entity.AppCustomer;
using System.Collections.Generic;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IInvoiceProductRepository : IBaseRepository<InvoiceProduct>
    {
        IEnumerable<InvoiceProduct> GetInvoiceProductsByCustomerPhoneNumber(string phoneNumber);
        int GetNumberOfProductByInvoiceId(int invoiceId, int productId);
    }
}