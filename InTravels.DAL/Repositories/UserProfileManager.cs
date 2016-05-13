using InTravels.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTravels.DAL.Entities;
using InTravels.DAL.EF;

namespace InTravels.DAL.Repositories
{
    public class UserProfileManager : IUserProfileManager
    {
        public ApplicationContext Database { get; set; }
        public UserProfileManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(UserProfile item)
        {
            Database.UserProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
