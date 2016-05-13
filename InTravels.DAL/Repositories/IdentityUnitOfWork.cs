using InTravels.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTravels.DAL.Entities;
using InTravels.DAL.EF;
using InTravels.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InTravels.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IUserProfileManager userProfileManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            userProfileManager = new UserProfileManager(db);
        }

        private PostRepository postRepository;
        private CommentRepository commentRepository;


        #region IdentityManagers properties
        public IUserProfileManager UserProfileManager
        {
            get
            {
                return userProfileManager;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return roleManager;
            }
        }
        #endregion

        #region EF entities repositories

        public IRepository<Post> Posts
        {
            get
            {
                if (postRepository == null)
                {
                    postRepository = new PostRepository(db);
                }
                return postRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new CommentRepository(db);
                }
                return commentRepository;
            }
        }
        #endregion

        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    userProfileManager.Dispose();
                    db.Dispose();
                }
                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
