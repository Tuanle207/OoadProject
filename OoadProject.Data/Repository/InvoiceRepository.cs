using OoadProject.Data.Entity.AppCustomer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class InvoiceRepository : BaseRepository<Invoice>
    {
        public int GetSalesByDay(DateTime day)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.InvoiceProducts
                    .Where(ip => DbFunctions.TruncateTime(ip.Invoice.CreationTime) == day.Date);

                return query.Any() ? query.Sum(ip => ip.Number): 0;
            }
        }

        public int GetSalesByMonth(DateTime day)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.InvoiceProducts
                    .Where(ip => ip.Invoice.CreationTime.Month == day.Month && ip.Invoice.CreationTime.Year == day.Year);

                return query.Any() ? query.Sum(ip => ip.Number) : 0;
            }

        }

        public int GetRevenueByDay(DateTime day)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.Invoices
                    .Where(i => DbFunctions.TruncateTime(i.CreationTime) == day.Date);

                return query.Any() ? query.Sum(i => i.Total) : 0;
            }
        }

        public int GetRevenueByMonth(DateTime day)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.Invoices
                    .Where(i => i.CreationTime.Month == day.Month && i.CreationTime.Year == day.Year);

                return query.Any() ? query.Sum(i => i.Total) : 0;
            }
        }
        
    }
}
