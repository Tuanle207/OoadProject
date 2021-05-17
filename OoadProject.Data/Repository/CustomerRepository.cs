using OoadProject.Data.Entity.AppCustomer;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OoadProject.Shared.Pagination;
using OoadProject.Shared.Dtos;

namespace OoadProject.Data.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public Customer GetCustomByPhoneNumber(string phoneNumber)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.Customers.AsQueryable();
                query = query.Where(q => q.PhoneNumber == phoneNumber);
                query = query.Include(p => p.CustomerLevel);
                return query.FirstOrDefault();
                //var customer = ctx.Customers.Where(q => q.PhoneNumber == phoneNumber).FirstOrDefault();
            }
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var ctx = new AppDbContext())
            {
                var customers = ctx.Customers
                    .FilterDeleted()
                    .Include(u => u.CustomerLevel)
                    .ToList();
                return customers;
            }
        }

        public PaginatedList<Customer> GetCustomers(int page, int limit, CustomerFilterDto Filter = null)
        {
            using (var ctx = new AppDbContext())
            {
                var query = ctx.Customers.AsQueryable();
                query = query.Where(p => p.IsDeleted == false);
                if (Filter != null)
                {
                    if (Filter.NameCustomerKeyWord != null && Filter.NameCustomerKeyWord != "")
                    {
                        query = query.Where(p => p.Name.ToLower().Contains((Filter.NameCustomerKeyWord).ToLower()));
                    }
                }
                query = query.Include(p => p.CustomerLevel)
                    .OrderBy(p => p.Id);
                var customers = PaginatedList<Customer>.Create(query, page, limit);

                return customers;
            }
        }

    }

    static class Extension1
    {
        public static IQueryable<Customer> FilterDeleted(this IQueryable<Customer> query)
        {
            return query.Where(u => u.IsDeleted != true);
        }
    }
}

