﻿namespace OoadProject.Data.Migrations
{
    using OoadProject.Data.Seedings;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OoadProject.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OoadProject.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            UserSeeder.CreateAdminUser(context);
            ParameterSeeder.Seed(context);
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
