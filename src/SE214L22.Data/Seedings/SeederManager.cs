namespace SE214L22.Data.Seedings
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
            OrderSeeder.Seed(context);
            InvoiceSeeder.Seed(context);
        }
    }
}
