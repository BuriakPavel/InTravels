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
    }

    public class DbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
           
        }
    }
}