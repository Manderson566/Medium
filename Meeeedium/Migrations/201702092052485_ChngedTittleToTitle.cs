namespace Meeeedium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChngedTittleToTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Title", c => c.String());
            DropColumn("dbo.Blogs", "Titile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Titile", c => c.String());
            DropColumn("dbo.Blogs", "Title");
        }
    }
}
