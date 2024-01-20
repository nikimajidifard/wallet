using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using Wallet.Application.Contracts;
using Wallet.Infrastructure.Data;
using AutoMapper;
using System.Transactions;
using static System.TimeZoneInfo;
using wallet.Domain.Entities;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Wallet.Application.Services.Search
{
    internal class SearchEngineServices : ISearchEngine
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CompanySearch companySearchengine;
        private readonly UserSearch UserSearchengine;
        private readonly TransactionSearch TransactionSearchengine;
        private readonly WalletSearch walletSearchengine;

        public SearchEngineServices(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            this.companySearchengine = new CompanySearch(_dbContext, _mapper);
            this.UserSearchengine = new UserSearch(_dbContext, _mapper);
            this.TransactionSearchengine = new TransactionSearch(_dbContext, _mapper);
            this.walletSearchengine = new WalletSearch(_dbContext, _mapper);

        }
        public CompanySearch CompanySearchService()
        {
            return companySearchengine;
        }

        public TransactionSearch searchTransactionService()
        {
            return TransactionSearchengine;
        }

        public WalletSearch SearchWalletService()
        {
            return walletSearchengine;
        }

        public UserSearch UserSearchService()
        {
            return UserSearchengine;
        }
    }
}
