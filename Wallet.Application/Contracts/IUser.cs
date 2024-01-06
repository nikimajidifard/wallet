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
        string CreateUser(UserDto user, int CompanyId);
        string DeleteUser(UserDto user, int UserId);
        string UpdateUser(UserDto user);
        List<UserDto> GetALLUsers();
        UserDto GetUser(int UserId);
    }
}
