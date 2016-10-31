namespace InTravels.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Rating_and_FollowedUsers_to_UserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Rating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.UserProfiles", "UserProfile_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserProfiles", "UserProfile_Id");
            AddForeignKey("dbo.UserProfiles", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserProfiles", new[] { "UserProfile_Id" });
            DropColumn("dbo.UserProfiles", "UserProfile_Id");
            DropColumn("dbo.UserProfiles", "Rating");
        }
    }
}
