using AutoMapper;
using InTravels.BLL.DTO;
using InTravels.BLL.Interfaces;
using InTravels.WebAPI.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace InTravels.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        [Authorize]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public JsonResult<UserProfileViewModel> GetProfile(UserEmailViewModel userEmail)
        {
            UserProfileViewModel result = new UserProfileViewModel();
            var errors = new Dictionary<string, object>();

            UserDTO userDto = userService.GetUserByEmail(userEmail.Email);
            if (userDto != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, UserProfileViewModel>());
                var userProfileVM = Mapper.Map<UserDTO, UserProfileViewModel>(userDto);
                result = userProfileVM;
            }
            else
            {
                errors.Add("", "User is not exist");
            }

            result.Errors = errors;

            return Json(result);
        }
    }
}