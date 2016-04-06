namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaylistUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "PlaylistId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "PlaylistId");
        }
    }
}
