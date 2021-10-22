using SE214L22.Data.Entity.AppProduct;
using SE214L22.Shared.Dtos;
using System.Collections.Generic;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IReceiptRepository : IBaseRepository<Receipt>
    {
        IEnumerable<Receipt> GetAll(DateRangeDto dateRange);
    }
}