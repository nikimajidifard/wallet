using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using Wallet.Infrastructure.Data;
using wallet.Domain.Entities;

namespace Wallet.Application.Services
{
    public class UserServices : IUser
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;
        public UserServices(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public string CreateUser(UserDto userdto, int companyId)
        {
            var company = _dbContext.Companies.FirstOrDefault(u => u.CompanyId == companyId);
            if (company == null)
            {
                return "company not found";
            }
            var user = _mapper.Map<User>(userdto);
            user.CompanyID= companyId;
            user.Company = company;
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return "user was created";
        }

        public string DeleteUser(UserDto user, int userId)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetALLUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public string UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
