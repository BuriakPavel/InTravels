using InTravels.DAL.Entities;
using System;

namespace InTravels.DAL.Interfaces
{
    public interface IUserProfileManager : IDisposable
    {
        void Create(UserProfile item);
    }
}