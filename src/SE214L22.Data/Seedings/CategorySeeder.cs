using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Data.Seedings
{
    public class CategorySeeder
    {
        private static List<Category> Data
        {
            get
            {
                return new List<Category>()
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Laptop",
                        Description = null,
                        ReturnRate = 25.0f

                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Chuột",
                        Description = null,
                        ReturnRate = 25.0f
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Bàn phím",
                        Description = null,
                        ReturnRate = 25.0f

                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Tai nghe",
                        Description = null,
                        ReturnRate = 25.0f

                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Loa",
                        Description = null,
                        ReturnRate = 25.0f

                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Ổ cứng",
                        Description = null,
                        ReturnRate = 25.0f

                    },
                    new Category
                    {
                        Id = 7,
                        Name = "Màn hình",
                        Description = null,
                        ReturnRate = 25.0f

                    },
                    new Category
                    {
                        Id = 8,
                        Name = "Ram",
                        Description = null,
                        ReturnRate = 25.0f
                    }
                };
            }
        }

        public static void Seed(AppDbContext context)
        {
            foreach (var item in Data)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();
        }
    }
}
