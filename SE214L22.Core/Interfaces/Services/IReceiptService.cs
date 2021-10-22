using SE214L22.Core.ViewModels.Orders.Dtos;
using SE214L22.Shared.Dtos;
using System.Collections.Generic;

namespace SE214L22.Core.Interfaces.Services
{
    public interface IReceiptService : IBaseService
    {
        void AddNewReceipt(OrderForListDto order, IEnumerable<ProductForReceiptCreation> receiptProducts);
        IEnumerable<ReceiptForListDto> GetAllReceipts(DateRangeDto dateRange);
        IEnumerable<ProductForReceiptCreation> GetReceiptProducts(int id);
    }
}