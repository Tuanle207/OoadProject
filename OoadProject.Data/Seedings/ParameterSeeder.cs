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
        public static void Seed(AppDbContext context)
        {
            context.Parameters.Add(new Parameter
            {
                Key = "MinInputProductNumber",
                Value = 5
            });
            context.Parameters.Add(new Parameter
            {
                Key = "MaxInputProductNumber",
                Value = 100
            });
            context.Parameters.Add(new Parameter
            {
                Key = "MinAge",
                Value = 18
            });
            context.Parameters.Add(new Parameter
            {
                Key = "MaxAge",
                Value = 35
            });
            context.SaveChanges();
        }
    }
}
