using OoadProject.Data.Entity.AppCustomer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OoadProject.Data.Repository
{
    public class InvoiceRepository
    {
        public IEnumerable<InvoiceProduct> GetInvoiceProductsByDay(DateTime day)
        {
            using (var ctx = new AppDbContext())
            {
                var list = ctx.InvoiceProducts
                    .Where(ip => ip.Invoice.CreationTime.Equals(day))
                    .Include(ip => ip.Product).ToList();

                return list;
            }
        }

        public IEnumerable<InvoiceProduct> GetInvoiceProductsByMonth(DateTime day)
        {
            using (var ctx = new AppDbContext())
            {
                var list = ctx.InvoiceProducts
                    .Where(ip => ip.Invoice.CreationTime.Equals(day))
                    .Include(ip => ip.Product).ToList();

                return list;
            }

        }

    }
}
