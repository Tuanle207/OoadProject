using SE214L22.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE214L22.Contract.DTOs
{
    public class CustomerDisplayDto : BaseDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int CustomerLevelId { get; set; }
        public string PhoneNumber { get; set; }
        public float AccumulatedPoint { get; set; }
        public DateTime CreationTime { get; set; }
        public CustomerLevel CustomerLevel { get; set; }

    }
}
