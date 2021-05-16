namespace OoadProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Photo_Data_Properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Photo", c => c.String());
            AddColumn("dbo.Products", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Photo");
            DropColumn("dbo.Users", "Photo");
        }
    }
}
