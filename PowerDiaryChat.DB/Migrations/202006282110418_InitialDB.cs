namespace PowerDiaryChat.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ChatEvent = c.Int(nullable: false),
                        ChatDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommentChat",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.HighFiveChat",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HighFivedUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.Id)
                .ForeignKey("dbo.Users", t => t.HighFivedUserId)
                .Index(t => t.Id)
                .Index(t => t.HighFivedUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HighFiveChat", "HighFivedUserId", "dbo.Users");
            DropForeignKey("dbo.HighFiveChat", "Id", "dbo.Chats");
            DropForeignKey("dbo.CommentChat", "Id", "dbo.Chats");
            DropForeignKey("dbo.Chats", "UserId", "dbo.Users");
            DropIndex("dbo.HighFiveChat", new[] { "HighFivedUserId" });
            DropIndex("dbo.HighFiveChat", new[] { "Id" });
            DropIndex("dbo.CommentChat", new[] { "Id" });
            DropIndex("dbo.Chats", new[] { "UserId" });
            DropTable("dbo.HighFiveChat");
            DropTable("dbo.CommentChat");
            DropTable("dbo.Users");
            DropTable("dbo.Chats");
        }
    }
}
