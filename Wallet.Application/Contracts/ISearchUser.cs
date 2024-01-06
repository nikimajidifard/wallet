using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Wallet.Application.DTOs;
using wallet.Domain.Enums;


namespace Wallet.Application.Contracts
{
    public interface ISearchUser
    {
        UserDto GetUserbyId(int userID);
        UserDto GetUserbyUsername(string userName);
        UserDto GetUserbyPhone(string userPhone);
        List<UserDto> GetUsersbyCompany(int companyID);
        UserDto GetUserbywallet(int walletId);
        List<UserDto> GetUserbyRole(string userRole);

    }
}
