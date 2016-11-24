using AutoMapper;
using InTravels.BLL.DTO;
using InTravels.BLL.Interfaces;
using InTravels.WebAPI.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InTravels.WebAPI.Controllers
{
    [RoutePrefix("api/UserProfile")]
    public class UserApiController : BaseApiController
    {
        IUserService userService;
        public UserApiController()
        { }

        public UserApiController(IUserService serv)
        {
            userService = serv;
        }

        [HttpPost]
        [Route("GetProfile")]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        public UserProfileViewModel GetProfile(UserEmailViewModel userEmail)
        {
            UserDTO userDto = userService.GetUserByEmail(userEmail.Email);
            Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, UserProfileViewModel>());
            var userProfileVM = Mapper.Map<UserDTO, UserProfileViewModel>(userDto);

            return userProfileVM; 
        }
    }
}