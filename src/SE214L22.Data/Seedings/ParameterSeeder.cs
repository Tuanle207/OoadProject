using SE214L22.Contract.Entities;
using SE214L22.Shared.Parameters;
using System.Collections.Generic;

namespace SE214L22.Data.Seedings
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
                        Key = ParameterType.MinInputProductNumber,
                        Value = 5
                    },
                    new Parameter
                    {
                        Id = 2,
                        Key = ParameterType.MaxInputProductNumber,
                        Value = 100
                    },
                    new Parameter
                    {
                        Id = 3,
                        Key = ParameterType.MinAge,
                        Value = 18
                    },
                    new Parameter
                    {
                        Id = 4,
                        Key = ParameterType.MaxAge,
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
