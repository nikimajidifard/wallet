using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;

namespace Wallet.Application.Contracts
{
    public interface IUser
    {
        string CreateUser(UserDto user, int companyId);
        string DeleteUser(UserDto user, int userId);
        string UpdateUser(UserDto user);
        List<UserDto> GetALLUsers();
        UserDto GetUser(int userId);
    }
}
