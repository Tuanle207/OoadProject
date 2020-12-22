using OoadProject.Data.Entity.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Seedings
{
    public class ParameterSeeder
    {
        private static List<Parameter> Data
        {
            get {
                return new List<Parameter>()
                {
                    new Parameter
                    {
                        Id = 1,
                        Key = "MinInputProductNumber",
                        Value = 5
                    },
                    new Parameter
                    {
                        Id = 2,
                        Key = "MaxInputProductNumber",
                        Value = 100
                    },
                    new Parameter
                    {
                        Id = 3,
                        Key = "MinAge",
                        Value = 18
                    },
                    new Parameter
                    {
                        Id = 4,
                        Key = "MaxAge",
                        Value = 35
                    }
                };
            }
        }
        public static void Seed(AppDbContext context)
        {
            foreach (var item in Data)
            {
                context.Parameters.Add(item);
            }
            
            context.SaveChanges();
        }
    }
}
