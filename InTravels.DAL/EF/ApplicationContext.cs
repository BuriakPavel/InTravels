using InTravels.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace InTravels.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<UserProfile> UserProfiles { get; set; }
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Comment> Comments { get; set; }

        public ApplicationContext(string connectionString) : base(connectionString)
        {

        }
    }

	public class PostDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
	{
		protected override void Seed(ApplicationContext db)
		{
			db.Posts.Add(new Post { Title = "Post title #1", Text = "Post content text #1", Date = DateTime.Now.Date.AddDays(-12)});
			db.Posts.Add(new Post { Title = "Post title #2", Text = "Post content text #2", Date = DateTime.Now.Date.AddDays(-5) });
			db.Posts.Add(new Post { Title = "Post title #3", Text = "Post content text #3", Date = DateTime.Now.Date.AddDays(-1) });

			base.Seed(db);
		}
	}

	public class DbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
           
        }
    }
}