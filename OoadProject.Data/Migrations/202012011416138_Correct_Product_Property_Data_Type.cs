namespace OoadProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct_Product_Property_Data_Type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.Int(nullable: false));
        }
    }
}
