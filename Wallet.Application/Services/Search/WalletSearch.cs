using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using wallet.Domain.Enums;
using Wallet.Infrastructure.Data;
using AutoMapper;
using System.Transactions;
using static System.TimeZoneInfo;
using wallet.Domain.Entities;
using System.Collections;


namespace Wallet.Application.Services.Search
{
    public class WalletSearch : ISearchWalletE
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;

        public WalletSearch(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<WalletEDto> GetWalletbyBalance(float WalletBalance)
        {
            var filteredWallets = _dbContext.Wallets.Where(t => t.WalletBalance == WalletBalance).ToList();
            var WalletDtos = _mapper.Map<List<WalletEDto>>(filteredWallets);
            return WalletDtos;
        }

        public WalletEDto GetWalletbyId(int WalletID)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(u => u.WalletId == WalletID);
            if (wallet == null)
                return null;

            var walletDto = _mapper.Map<WalletEDto>(wallet);

            return walletDto;
        }

        public List<WalletEDto> GetWalletbyState(bool State)
        {

            var filteredWallets = _dbContext.Wallets.Where(t => t.IsBlocked == State).ToList();
            var WalletDtos = _mapper.Map<List<WalletEDto>>(filteredWallets);
            return WalletDtos;
        }

        public List<WalletEDto> GetWalletbyUserId(int UserID)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(u => u.UserId == UserID);
            if (wallet == null)
                return null;

            var walletDto = _mapper.Map<list<WalletEDto>>(wallet);

            return walletDto;
        }

    }
}
