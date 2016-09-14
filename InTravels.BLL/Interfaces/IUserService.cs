using InTravels.BLL.DTO;
using InTravels.BLL.Infrastructure;
using InTravels.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InTravels.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateUser(UserDTO userDTO);
		Task<OperationDetails> UpdateUser(UserDTO userDTO);
		UserDTO GetUserByEmail(string email);
        Task<ClaimsIdentity> Authenticate(UserDTO userDTO);
        Task SetInitialData(UserDTO adminDTO, List<string> roles);
    }
}
