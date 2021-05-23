using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Seedings
{
    public class SeederManager
    {
        public static void Seed(AppDbContext context)
        {
            UserSeeder.Seed(context);
            ParameterSeeder.Seed(context);
            CategorySeeder.Seed(context);
            ManufactureSeeder.Seed(context);
            ProductSeeder.Seed(context);
            ProviderSeeder.Seed(context);
            CustomerLevelSeeder.Seed(context);
            CustomerSeeder.Seed(context);
        }
    }
}
