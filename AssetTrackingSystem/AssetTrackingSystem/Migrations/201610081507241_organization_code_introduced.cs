namespace AssetTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class organization_code_introduced : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Organizations", "ShortName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "ShortName", c => c.String(nullable: false, maxLength: 3));
            DropColumn("dbo.Organizations", "Code");
        }
    }
}
