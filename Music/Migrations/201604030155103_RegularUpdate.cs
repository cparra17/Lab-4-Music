namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegularUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Likes", c => c.Int(nullable: false));
            DropColumn("dbo.Albums", "Like");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "Like", c => c.Int(nullable: false));
            DropColumn("dbo.Albums", "Likes");
        }
    }
}
