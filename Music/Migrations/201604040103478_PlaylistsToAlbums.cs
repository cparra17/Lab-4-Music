namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaylistsToAlbums : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Playlist_PlaylistId", "dbo.Playlists");
            DropIndex("dbo.Albums", new[] { "Playlist_PlaylistId" });
            CreateTable(
                "dbo.PlaylistAlbums",
                c => new
                    {
                        Playlist_PlaylistId = c.Int(nullable: false),
                        Album_AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_PlaylistId, t.Album_AlbumID })
                .ForeignKey("dbo.Playlists", t => t.Playlist_PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumID, cascadeDelete: true)
                .Index(t => t.Playlist_PlaylistId)
                .Index(t => t.Album_AlbumID);
            
            DropColumn("dbo.Albums", "Playlist_PlaylistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "Playlist_PlaylistId", c => c.Int());
            DropForeignKey("dbo.PlaylistAlbums", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.PlaylistAlbums", "Playlist_PlaylistId", "dbo.Playlists");
            DropIndex("dbo.PlaylistAlbums", new[] { "Album_AlbumID" });
            DropIndex("dbo.PlaylistAlbums", new[] { "Playlist_PlaylistId" });
            DropTable("dbo.PlaylistAlbums");
            CreateIndex("dbo.Albums", "Playlist_PlaylistId");
            AddForeignKey("dbo.Albums", "Playlist_PlaylistId", "dbo.Playlists", "PlaylistId");
        }
    }
}
