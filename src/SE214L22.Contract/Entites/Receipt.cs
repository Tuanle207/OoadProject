using System;
using System.Collections.Generic;

namespace SE214L22.Contract.Entities
{
    public class Receipt : AppEntity
    {
        public int UserId { get; set; }
        public DateTime CreationTime { get; set; }
        public int? OrderId { get; set; }
        public int Total { get; set; }

        public Order Order { get; set; }
        public User CreationUser { get; set; }
        public ICollection<ReceiptProduct> ReceiptProducts { get; set; }
    }
}
