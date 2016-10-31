namespace InTravels.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Fixes_and_new_entities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserProfiles", new[] { "UserProfile_Id" });
            RenameColumn(table: "dbo.Comments", name: "ParentComment_Id", newName: "ParentCommentId");
            RenameColumn(table: "dbo.Comments", name: "Post_Id", newName: "PostId");
            RenameColumn(table: "dbo.Comments", name: "UserId", newName: "UserProfileId");
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "UserProfileId");
            RenameIndex(table: "dbo.Comments", name: "IX_Post_Id", newName: "IX_PostId");
            RenameIndex(table: "dbo.Comments", name: "IX_ParentComment_Id", newName: "IX_ParentCommentId");
            RenameIndex(table: "dbo.Comments", name: "IX_UserId", newName: "IX_UserProfileId");
            RenameIndex(table: "dbo.Posts", name: "IX_User_Id", newName: "IX_UserProfileId");
            CreateTable(
                "dbo.TravelCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 10),
                        Description = c.String(maxLength: 50),
                        IconPath = c.String(),
                        LocaleCode = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 15),
                        LocaleCode = c.String(maxLength: 5),
                        Post_Id = c.Int(),
                        Comment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.UserProfileUserProfiles",
                c => new
                    {
                        UserProfile_Id = c.String(nullable: false, maxLength: 128),
                        UserProfile_Id1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserProfile_Id, t.UserProfile_Id1 })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id1)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id1);
            
            AddColumn("dbo.Posts", "CategoryId", c => c.Int());
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.TravelCategories", "Id");
            DropColumn("dbo.UserProfiles", "UserProfile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "UserProfile_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Tags", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.UserProfileUserProfiles", "UserProfile_Id1", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfileUserProfiles", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Tags", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.TravelCategories");
            DropIndex("dbo.UserProfileUserProfiles", new[] { "UserProfile_Id1" });
            DropIndex("dbo.UserProfileUserProfiles", new[] { "UserProfile_Id" });
            DropIndex("dbo.Tags", new[] { "Comment_Id" });
            DropIndex("dbo.Tags", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropColumn("dbo.Posts", "CategoryId");
            DropTable("dbo.UserProfileUserProfiles");
            DropTable("dbo.Tags");
            DropTable("dbo.TravelCategories");
            RenameIndex(table: "dbo.Posts", name: "IX_UserProfileId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_UserProfileId", newName: "IX_UserId");
            RenameIndex(table: "dbo.Comments", name: "IX_ParentCommentId", newName: "IX_ParentComment_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_PostId", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.Posts", name: "UserProfileId", newName: "User_Id");
            RenameColumn(table: "dbo.Comments", name: "UserProfileId", newName: "UserId");
            RenameColumn(table: "dbo.Comments", name: "PostId", newName: "Post_Id");
            RenameColumn(table: "dbo.Comments", name: "ParentCommentId", newName: "ParentComment_Id");
            CreateIndex("dbo.UserProfiles", "UserProfile_Id");
            AddForeignKey("dbo.UserProfiles", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
    }
}
