namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaylistUpdate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
            AddColumn("dbo.Albums", "Playlist_PlaylistId", c => c.Int());
            CreateIndex("dbo.Albums", "Playlist_PlaylistId");
            AddForeignKey("dbo.Albums", "Playlist_PlaylistId", "dbo.Playlists", "PlaylistId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Playlist_PlaylistId", "dbo.Playlists");
            DropIndex("dbo.Albums", new[] { "Playlist_PlaylistId" });
            DropColumn("dbo.Albums", "Playlist_PlaylistId");
            DropTable("dbo.Playlists");
        }
    }
}
