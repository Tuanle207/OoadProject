namespace OoadProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "AccumulatedPoint", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "AccumulatedPoint", c => c.Int(nullable: false));
        }
    }
}
