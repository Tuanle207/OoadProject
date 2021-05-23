using OoadProject.Data.Entity.AppCustomer;
using OoadProject.Data.Entity.AppProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Seedings
{
    public class CustomerLevelSeeder
    {
        private static List<CustomerLevel> Data
        {
            get
            {
                return new List<CustomerLevel>()
                {
                    new CustomerLevel
                    {
                        Id = 1,
                        Name = "Hạng Đồng",
                        Description = null,
                        PointLevel = 10000000.0f,
                        Discount = 2.0f
                    },
                    new CustomerLevel
                    {
                        Id = 1,
                        Name = "Hạng Bạc",
                        Description = null,
                        PointLevel = 40000000.0f,
                        Discount = 4.0f
                    },
                    new CustomerLevel
                    {
                        Id = 1,
                        Name = "Hạng Vàng",
                        Description = null,
                        PointLevel = 100000000.0f,
                        Discount = 5.0f
                    },
                };
            }
        }
        public static void Seed(AppDbContext context)
        {
            foreach (var item in Data)
            {
                context.CustomerLevels.Add(item);
            }

            context.SaveChanges();
        }
    }
}
