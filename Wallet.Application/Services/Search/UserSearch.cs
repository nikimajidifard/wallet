using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using wallet.Domain.Enums;
using Wallet.Application.Contracts;
using Wallet.Infrastructure.Data;
using AutoMapper;
using System.Transactions;
using static System.TimeZoneInfo;
using wallet.Domain.Entities;
using System.Collections;

namespace Wallet.Application.Services.Search
{
    public class UserSearch : ISearchUser
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;

        public UserSearch(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<UserDto> GetUserbyRole(string UserRole)
        {
            var filteredUsers = _dbContext.Users.Where(t => t.UserRole == UserRole).ToList();
            var UserDtos = _mapper.Map<List<UserDto>>(filteredUsers);
            return UserDtos;
        }

        public UserDto GetUserbyId(int UserID)
        {
            var User = _dbContext.Users.FirstOrDefault(u => u.UserId == UserID);
            if (User == null)
                return null;

            var UserDto = _mapper.Map<UserDto>(User);

            return UserDto;
        }

        public UserDto GetUserbyPhone(string UserPhone)
        {
            var User = _dbContext.Users.FirstOrDefault(u => u.UserPhone == UserPhone);
            if (User == null)
                return null;

            var UserDto = _mapper.Map<UserDto>(User);

            return UserDto;
        }

        public UserDto GetUserbyUsername(string UserName)
        {
            var User = _dbContext.Users.FirstOrDefault(u => u.UserName == UserName);
            if (User == null)
                return null;

            var UserDto = _mapper.Map<UserDto>(User);

            return UserDto;
        }

        public UserDto GetUserbywallet(int WalletId)
        {
            var User = _dbContext.Wallets.FirstOrDefault(u => u.WalletId == WalletId);
            if (User == null)
                return null;

            var UserDto = _mapper.Map<UserDto>(User);

            return UserDto;
        }

        public List<UserDto> GetUsersbyCompany(int CompanyID)
        {
            var filteredUsers = _dbContext.Users.Where(t => t.CompanyID == CompanyID).ToList();
            var UserDtos = _mapper.Map<List<UserDto>>(filteredUsers);
            return UserDtos;
        }

    }
}
