using OoadProject.Data.Entity.AppUser;
using System;
using System.Collections.Generic;

namespace OoadProject.Data.Entity.AppCustomer
{
    public class Invoice : AppEntity
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public DateTime CreationTime { get; set; }
        public int Total { get; set; }

        public User CreationUser { get; set; }
        public Customer Customer { get; set; }
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
