using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;

namespace Wallet.Application.Services
{
    public class SearchUser : ISearchUser
    {
        private readonly WalletDBContext _dbContext;
        public UserDto GetUserbyId(int userID)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserbyPhone(string userPhone)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetUserbyRole(string userRole)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserbyUsername(string userName)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserbywallet(int walletId)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetUsersbyCompany(int companyID)
        {
            throw new NotImplementedException();
        }
    }
}
