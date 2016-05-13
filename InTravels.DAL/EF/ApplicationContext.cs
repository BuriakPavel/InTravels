using InTravels.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace InTravels.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationContext(string connectionString) : base(connectionString)
        {
        }
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new DbInitializer());
        }
    }

    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            db.Posts.Add(new Post()
            {
                Title = "Test Title 1",
                Date = DateTime.Now,
                Text = "Test posts text 1",
                Comments = new List<Comment>() { new Comment() { Date = DateTime.Now, Likes = 2, Text = "Test comment by post 1" } }
            });
            db.Posts.Add(new Post()
            {
                Title = "Test Title 2",
                Date = DateTime.Now,
                Text = "Test posts text 2",
                Comments = new List<Comment>() { new Comment() { Date = DateTime.Now, Likes = 0, Text = "Test comment by post 2" } }
            });
            db.Posts.Add(new Post()
            {
                Title = "Test Title 3",
                Date = DateTime.Now,
                Text = "Test posts text 3",
                Comments = new List<Comment>() { new Comment() { Date = DateTime.Now, Likes = -1, Text = "Test comment by post 3" } }
            });
            db.SaveChanges();
        }
    }
}