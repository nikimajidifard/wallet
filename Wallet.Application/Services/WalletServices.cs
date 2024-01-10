using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using AutoMapper;
using Wallet.Infrastructure.Data;
using wallet.Domain.Entities;


namespace Wallet.Application.Services
{
    public class WalletServices : IWallet
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;
        public WalletServices(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public string CreateWallet(WalletEDto walletdto, int UserId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == UserId);
            if (user == null)
                return "user not found";
            
            var Wallet = _mapper.Map<WalletE>(walletdto);
            Wallet.User = user;
            Wallet.UserId= UserId;
            _dbContext.Add(walletdto);
            _dbContext.SaveChanges();
            return "wallet was added";

        }

        public string DeleteWallet(WalletEDto wallet, int UserId)
        {
            throw new NotImplementedException();
        }

        public float GetBalance(int WalletId)
        {
            throw new NotImplementedException();
        }

        public WalletEDto GetWallet(int UserId)
        {
            throw new NotImplementedException();
        }

        public List<WalletEDto> GetWallets()
        {
            throw new NotImplementedException();
        }

        public List<LabelDto> Labels(int WalletId)
        {
            throw new NotImplementedException();
        }

        public string UpdateWallet(WalletEDto wallet, float NewBalance, int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
