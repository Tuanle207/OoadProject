using SE214L22.Contract.Entities;
using SE214L22.Shared.Dtos;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IReceiptRepository : IBaseRepository<Receipt>
    {
        IEnumerable<Receipt> GetAll(DateRangeDto dateRange);
    }
}