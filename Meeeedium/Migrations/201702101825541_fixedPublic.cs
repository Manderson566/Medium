namespace Meeeedium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedPublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Public", c => c.Boolean(nullable: false));
            DropColumn("dbo.Blogs", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "MyProperty", c => c.Boolean(nullable: false));
            DropColumn("dbo.Blogs", "Public");
        }
    }
}
