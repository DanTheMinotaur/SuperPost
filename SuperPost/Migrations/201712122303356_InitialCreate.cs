namespace SuperPost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        Post_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Post", t => t.Post_ID)
                .ForeignKey("dbo.User", t => t.User_ID)
                .Index(t => t.Post_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryPost",
                c => new
                    {
                        Category_ID = c.Int(nullable: false),
                        Post_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_ID, t.Post_ID })
                .ForeignKey("dbo.Category", t => t.Category_ID, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.Post_ID, cascadeDelete: true)
                .Index(t => t.Category_ID)
                .Index(t => t.Post_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "User_ID", "dbo.User");
            DropForeignKey("dbo.Comment", "User_ID", "dbo.User");
            DropForeignKey("dbo.Comment", "Post_ID", "dbo.Post");
            DropForeignKey("dbo.CategoryPost", "Post_ID", "dbo.Post");
            DropForeignKey("dbo.CategoryPost", "Category_ID", "dbo.Category");
            DropIndex("dbo.CategoryPost", new[] { "Post_ID" });
            DropIndex("dbo.CategoryPost", new[] { "Category_ID" });
            DropIndex("dbo.Post", new[] { "User_ID" });
            DropIndex("dbo.Comment", new[] { "User_ID" });
            DropIndex("dbo.Comment", new[] { "Post_ID" });
            DropTable("dbo.CategoryPost");
            DropTable("dbo.User");
            DropTable("dbo.Category");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
