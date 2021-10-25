using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Data.Seedings
{
    public class ManufactureSeeder
    {
        private static List<Manufacturer> Data
        {
            get
            {
                return new List<Manufacturer>()
                {
                    new Manufacturer
                    {
                        Id = 1,
                        Name = "Apple",
                        Description = null
                    },
                    new Manufacturer
                    {
                        Id = 2,
                        Name = "Sony",
                        Description = null
                    },
                    new Manufacturer
                    {
                        Id = 3,
                        Name = "Asus",
                        Description = null
                    },
                    new Manufacturer
                    {
                        Id = 4,
                        Name = "Kingston",
                        Description = null
                    },
                    new Manufacturer
                    {
                        Id = 5,
                        Name = "Sony",
                        Description = null
                    },
                    new Manufacturer
                    {
                        Id = 6,
                        Name = "Dell",
                        Description = null
                    },
                    new Manufacturer
                    {
                        Id = 7,
                        Name = "SoundMax",
                        Description = null
                    },
                    new Manufacturer
                    {
                        Id = 8,
                        Name = "Logitech",
                        Description = null
                    },
                    new Manufacturer
                    {
                        Id = 9,
                        Name = "Samsung",
                        Description = null
                    }
                };
            }
        }
        public static void Seed(AppDbContext context)
        {
            foreach (var item in Data)
            {
                context.Manufacturers.Add(item);
            }

            context.SaveChanges();
        }
    }
}
