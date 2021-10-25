using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IInvoiceProductRepository : IBaseRepository<InvoiceProduct>
    {
        IEnumerable<InvoiceProduct> GetInvoiceProductsByCustomerPhoneNumber(string phoneNumber);
        int GetNumberOfProductByInvoiceId(int invoiceId, int productId);
    }
}