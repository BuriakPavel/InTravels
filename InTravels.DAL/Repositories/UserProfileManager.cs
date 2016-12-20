using InTravels.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTravels.DAL.Entities;
using InTravels.DAL.EF;
using System.Data.Entity;

namespace InTravels.DAL.Repositories
{
    public class UserProfileManager : IUserProfileManager
    {
        public ApplicationContext DB { get; set; }
        public UserProfileManager(ApplicationContext db)
        {
            DB = db;
        }

        public void Create(UserProfile item)
        {
            DB.UserProfiles.Add(item);
            DB.SaveChanges();
        }

        public UserProfile GetUserInfoByEmail(string email)
        {
            using (var db = DB)
            {
                var userProfile = db.UserProfiles
                    .Include(x => x.ApplicationUser)
                    .FirstOrDefault(x => x.ApplicationUser.Email == email);
                return userProfile;
            }
        }

        public void Dispose()
        {
            DB.Dispose();
        }

    }
}
