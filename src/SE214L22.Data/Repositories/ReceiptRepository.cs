using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Shared.Dtos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SE214L22.Data.Repositories
{
    public class ReceiptRepository : BaseRepository<Receipt>, IReceiptRepository
    {
        public IEnumerable<Receipt> GetAll(DateRangeDto dateRange)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.Receipts.AsQueryable();
                if (dateRange != null)
                {
                    dateRange.EndDate.AddDays(1);
                    query = query.Where(rc => dateRange.StartDate <= rc.CreationTime && rc.CreationTime <= dateRange.EndDate);
                }
                return query
                    .Include(rc => rc.Order)
                    .Include(rc => rc.Order.Provider)
                    .Include(rc => rc.CreationUser)
                    .ToList();
            }
        }
    }
}
