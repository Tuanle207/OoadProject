using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Repository.AggregateDto;
using OoadProject.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class ProductRepository
    {
        public IEnumerable<ProductAggregateDto> GetProductsOrderBySales(DateTime day, int limit = 10)
        {
            using (var ctx = new AppDbContext())
            {
                // group all alike productid and sum up sales no
                var hotProductIds = ctx.InvoiceProducts
                    .Include(p => p.Invoice)
                    .Where(p => p.Invoice.CreationTime.Month == day.Month && p.Invoice.CreationTime.Year == day.Year)
                    .GroupBy(p => p.ProductId)
                    .Select(p => new { ProductId = p.Key, SalesNo = p.Sum(i => i.Number) })
                    .OrderByDescending(r => r.SalesNo)
                    .Take(limit)
                    .ToList();

                // get all ids
                var Ids = hotProductIds.Select(x => x.ProductId).ToList();

                // get all products with those ids
                var list = ctx.Products
                    .Where(p => Ids.Contains(p.Id))
                    .Include(p => p.Manufacturer)
                    .ToList();

                // return data with sales no
                List<ProductAggregateDto> dataForReturn = new List<ProductAggregateDto>();
                foreach(var product in list)
                {
                    var salesNo = hotProductIds.Where(x => x.ProductId == product.Id).FirstOrDefault().SalesNo;
                    dataForReturn.Add(new ProductAggregateDto { Product = product, SalesNo = salesNo });
                }

                return dataForReturn.OrderByDescending(x => x.SalesNo).ToList();
            }
        }

        public PaginatedList<Product> GetProducts(int page, int limit)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.Products
                    .Include(p => p.Category)
                    .Include(p => p.Manufacturer)
                    .OrderBy(p => p.Name);
                
                var products = PaginatedList<Product>.Create(query, page, limit);
                
                return products;
            }
        }
    }
}
