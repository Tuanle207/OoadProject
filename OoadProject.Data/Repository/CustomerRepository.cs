using OoadProject.Data.Entity.AppCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {

        public Customer GetCustomByPhoneNumber(string phoneNumber)
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Customers.Where(ctm => ctm.PhoneNumber == phoneNumber).FirstOrDefault();
            }
        }
    }
}
