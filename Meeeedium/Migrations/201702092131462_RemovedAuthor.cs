namespace Meeeedium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAuthor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Author", c => c.String());
        }
    }
}
