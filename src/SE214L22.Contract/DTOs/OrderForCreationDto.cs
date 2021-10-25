using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE214L22.Contract.DTOs
{
    public class OrderForCreationDto
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int UserId { get; set; }
        public int ProviderId { get; set; }
        public int Status { get; set; }
    }
}
