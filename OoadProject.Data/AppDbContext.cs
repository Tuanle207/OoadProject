using OoadProject.Data.Entity.AppCustomer;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Entity.AppUser;
using OoadProject.Data.Entity.Others;
using System.Data.Entity;

namespace OoadProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=OOADDBConnectionString")
        {
            //Database.SetInitializer<AppDbContext>()
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
                        .HasMany(r => r.Permissions)
                        .WithMany(p => p.Roles)
                        .Map(rp =>
                        {
                            rp.MapLeftKey("RoleId");
                            rp.MapRightKey("PermissionId");
                            rp.ToTable("RolePermissions");
                        });
        }

        // AppUser
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        // AppProduct
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptProduct> ReceiptProducts{ get; set; }
        public DbSet<Provider> Providers { get; set; }

        // AppCustomer
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLevel> CustomerLevels { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public DbSet<WarrantyOrder> WarrantyOrders { get; set; }


        // Others
        public DbSet<Parameter> Parameters { get; set; }
    }
}
