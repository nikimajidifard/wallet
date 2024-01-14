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
using System.ComponentModel.Design;


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
        public List<WalletEDto> GetWallets()
        {
            var wallets = _dbContext.Wallets.ToList();
            var walletDtos = _mapper.Map<List<WalletEDto>>(wallets);
            return walletDtos;
        }
        public WalletEDto GetWallet(int UserId)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(w => w.UserId == UserId);
            if (wallet == null)
            {
                throw new WalletNotFoundException("wallet with ID {UserId} not found", UserId);
            }
            wallet.UserId = UserId;
            var walletdto = _mapper.Map<WalletEDto>(wallet);
            return walletdto ;
        }
        public string UpdateWallet(WalletEDto walletdto)
        {
            var wallet = _mapper.Map<WalletE>(walletdto);
            _dbContext.Wallets.Update(wallet);
            _dbContext.SaveChanges();
            return "wallet was updated";
        }


        public string DeleteWallet(int walletID)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(c => c.WalletId == walletID);
            _dbContext.Wallets.Remove(wallet);
            _dbContext.SaveChanges();
            return "wallet was removed";
        }

        public float GetBalance(int walletId)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(w =>w.WalletId == walletId);
            if (wallet == null)
            {
                throw new WalletNotFoundException("wallet with ID {walletId} not found", walletId);
            }
            return wallet.WalletBalance;

        }

        public List<LabelDto> GetLabels(int walletId)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(w => w.WalletId == walletId);
            if (wallet == null)
            {
                throw new WalletNotFoundException("wallet with ID {walletId} not found", walletId);
            }
            var labels = wallet.Labels;
            var labeldtos = _mapper.Map<List<LabelDto>>(labels);
            return labeldtos;
        }
    }
    public class WalletNotFoundException : Exception
    {
        public WalletNotFoundException(string message, int id) : base(message) { }
    }
}
