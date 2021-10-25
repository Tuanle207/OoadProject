using System;
using System.Collections.Generic;

namespace SE214L22.Contract.Entities
{
    public enum OrderStatus
    {
        WaitForSent,
        Sent,
        Done
    }

    public class Order : AppEntity
    {
        public DateTime CreationTime { get; set; }
        public int UserId { get; set; }
        public int ProviderId { get; set; }
        public int Status { get; set; }

        public User CreationUser { get; set; }
        public Provider Provider { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
