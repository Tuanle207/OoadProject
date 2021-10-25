using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Data.Seedings
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
                        PointLevel = 200.0f,
                        Discount = 5.0f
                    },
                    new CustomerLevel
                    {
                        Id = 2,
                        Name = "Hạng Bạc",
                        Description = null,
                        PointLevel = 400.0f,
                        Discount = 10.0f
                    },
                    new CustomerLevel
                    {
                        Id = 3,
                        Name = "Hạng Vàng",
                        Description = null,
                        PointLevel = 800.0f,
                        Discount = 20.0f
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
