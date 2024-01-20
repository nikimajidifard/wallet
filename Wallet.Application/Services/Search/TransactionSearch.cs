using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using wallet.Domain.Enums;
using Wallet.Application.DTOs;
using Wallet.Infrastructure.Data;
using AutoMapper;
using System.Transactions;
using static System.TimeZoneInfo;
using wallet.Domain.Entities;
using System.Collections;



namespace Wallet.Application.Services.Search
{
    public class TransactionSearch : ISearchTransaction
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;

        public TransactionSearch(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public TransactionDto GetTransactionbyId(int transactionID)
        {
            var transaction = _dbContext.Transactions.FirstOrDefault(u => u.TransactionId == transactionID);
            if (transaction == null)
                return null;


            var TransactionDto = _mapper.Map<TransactionDto>(transaction);

            return TransactionDto;


        }

        public List<TransactionDto> GetTransactionbyTime(DateTime TransactionTime)
        {

            // Filter transactions by the specified time
            var filteredTransactions = _dbContext.Transactions.Where(t => t.TransactionTime == TransactionTime).ToList();
            var transactioDtos = _mapper.Map<List<TransactionDto>>(filteredTransactions);
            return transactioDtos;


        }
        public List<TransactionDto> GetTransactionbyType(TransactionType TransactionType)
        {
            var filteredTransactions = _dbContext.Transactions.Where(t => t.TransactionType == TransactionType).ToList();
            var transactioDtos = _mapper.Map<List<TransactionDto>>(filteredTransactions);
            return transactioDtos;
        }

        public List<TransactionDto> GetTransactionbyValue(float TransactionValue)
        {
            var filteredTransactions = _dbContext.Transactions.Where(t => t.TransactionValue == TransactionValue).ToList();
            var transactioDtos = _mapper.Map<List<TransactionDto>>(filteredTransactions);
            return transactioDtos;

        }

        public List<TransactionDto> GetTransactionbyWallet(int walletID)
        {
            var filteredTransactions = _dbContext.Transactions.Where(t => t.WalletId == walletID).ToList();
            var transactioDtos = _mapper.Map<List<TransactionDto>>(filteredTransactions);
            return transactioDtos;


        }

        public List<TransactionDto> GetTransactionbyWalletStatus(Status status)
        {
            var filteredTransactions = _dbContext.Transactions.Where(t => t.TransactionStatus == status).ToList();
            var transactioDtos = _mapper.Map<List<TransactionDto>>(filteredTransactions);
            return transactioDtos;

        }
    }
}
