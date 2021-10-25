using System;

namespace SE214L22.Contract.Entities
{
    public enum WarrantyOrderStatus
    {
        WaitForSent,
        Sent,
        WaitForCustomer,
        Done
    }

    public class WarrantyOrder : AppEntity
    {
        public int ProductId { get; set; }
        public int? InvoiceId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime CreationTime { get; set; }
        public int Status { get; set; }


        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
        public Customer Customer { get; set; }
    }
}
