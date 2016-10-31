namespace InTravels.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_post_and_comment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Date", c => c.DateTime());
            AlterColumn("dbo.Comments", "Likes", c => c.Int());
            AlterColumn("dbo.Posts", "Date", c => c.DateTime());
            AlterColumn("dbo.Posts", "Likes", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Likes", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "Likes", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "Date", c => c.DateTime(nullable: false));
        }
    }
}
