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
            user.CompanyID = companyId;
            user.Company = company;
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return "user was created";
        }
        public List<UserDto> GetALLUsers()
        {
            var users = _dbContext.Users.ToList();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return userDtos;
        }
        public UserDto GetUser(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                throw new UserNotFoundException("user with ID {userId} not found", userId);
            }
            user.UserId = userId;
            var userdto = _mapper.Map<UserDto>(user);
            return userdto;
        }
        public string UpdateUser(UserDto userdto)
        {
            var user = _mapper.Map<Company>(userdto);
            _dbContext.Companies.Update(user);
            _dbContext.SaveChanges();
            return "user was updated";
        }

        public string DeleteUser(UserDto userdto)
        {
            var user = _mapper.Map<User>(userdto);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return "user was removed";

        }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message, int id) : base(message) { }
    }

}
