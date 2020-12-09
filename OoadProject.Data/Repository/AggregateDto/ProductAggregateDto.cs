using OoadProject.Data.Entity.AppProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository.AggregateDto
{
    public class ProductAggregateDto
    {
        public Product Product { get; set; }
        public int SalesNo { get; set; }
    }
}
