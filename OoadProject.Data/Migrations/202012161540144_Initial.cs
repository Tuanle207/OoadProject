namespace OoadProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Parameters", "Key", c => c.String());
            DropColumn("dbo.Parameters", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parameters", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Parameters", "Key");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Email");
        }
    }
}
