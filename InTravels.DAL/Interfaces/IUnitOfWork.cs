using InTravels.DAL.Entities;
using InTravels.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IUserProfileManager UserProfileManager { get; }

        IRepository<Post> Posts { get; }
        IRepository<Comment> Comments { get; }

        Task SaveAsync();
        void Save();
    }
}
