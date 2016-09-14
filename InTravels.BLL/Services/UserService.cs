﻿using InTravels.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTravels.BLL.DTO;
using InTravels.BLL.Infrastructure;
using System.Security.Claims;
using InTravels.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using InTravels.DAL.Entities;
using AutoMapper;

namespace InTravels.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork DB { get; set; }

        public UserService(IUnitOfWork context)
        {
            DB = context;
        }

        public async Task<OperationDetails> CreateUser(UserDTO userDTO)
        {
            ApplicationUser user = await DB.UserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDTO.Email, UserName = userDTO.Email };
                await DB.UserManager.CreateAsync(user, userDTO.Password);

                //await DB.UserManager.AddToRoleAsync(user.Id, userDTO.Role);

                UserProfile userProfile = new UserProfile {
                    Id = user.Id,
                    Address = userDTO.Address,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Age = userDTO.Age,
                    Gender = userDTO.Gender
                };
                DB.UserProfileManager.Create(userProfile);
                await DB.SaveAsync();
                return new OperationDetails(true, "Registration is successfully complete!", "");

            }
            else
            {
                return new OperationDetails(false, "A user with this login already exists", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDTO)
        {
            ClaimsIdentity claim = null;

            ApplicationUser user = await DB.UserManager.FindAsync(userDTO.Email, userDTO.Password);
            if (user != null)
                claim = await DB.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDTO adminDTO, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await DB.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await DB.RoleManager.CreateAsync(role);
                }
            }

            await CreateUser(adminDTO);
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public UserDTO GetUserByEmail(string email)
        {
            ApplicationUser user = DB.UserManager.FindByEmail(email);
			UserDTO userDto = new UserDTO()
			{
				Id = user.Id,
				Password = user.PasswordHash,
				Email = user.Email,
				UserName = user.Email,
				FirstName = user.UserProfile.FirstName,
				LastName = user.UserProfile.LastName,
				Address = user.UserProfile.Address,
				Age = user.UserProfile.Age,
				Gender = user.UserProfile.Gender
			};
			return userDto;
        }

		public async Task<OperationDetails> UpdateUser(UserDTO userDTO)
		{
			ApplicationUser user = await DB.UserManager.FindByEmailAsync(userDTO.Email);
			if (user != null)
			{
				Mapper.Initialize(c => c.CreateMap<UserDTO, UserProfile>());
				
				user.UserProfile = Mapper.Map<UserDTO, UserProfile>(userDTO);

				await DB.SaveAsync();
				return new OperationDetails(true, "Profile updates is successfully complete!", "");
			}
			else
			{
				return new OperationDetails(false, "A user with this login is not already exists", "Email");
			}
		}
	}
}
