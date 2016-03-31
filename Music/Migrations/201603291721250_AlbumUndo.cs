namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumUndo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Albums", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "Genre", c => c.String());
        }
    }
}
