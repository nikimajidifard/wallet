using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using Wallet.Infrastructure.Data;
using wallet.Domain.Enums;
using wallet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Wallet.Application.Services
{
    public class TransactionServices : ITransaction
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;

        public TransactionServices(WalletDBContext dbcontext, IMapper mapper ) 
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }
        public string Deposit(int walletId, float amount, string labelname)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(w => w.WalletId == walletId);
            var label = _dbContext.Labels.FirstOrDefault(l => l.WalletId == walletId && l.LabelName == labelname);
            if (wallet == null)
                return "wallet not found.";

            //bool flag = false;
            //if (label == null) { flag = true; }


            if (wallet.Labels.Contains(label) || label == null)
            {
                if (wallet.IsBlocked == false)
                {
                    var transaction = new Transaction
                    {
                        TransactionType = TransactionType.deposit,
                        TransactionStatus = Status.successful,
                        TransactionTime = DateTime.Now,
                        TransactionValue = amount,
                        Wallet = wallet,
                        Label = label
                        
                    };
                    if (label == null)
                    {
                        wallet.WalletBalance += amount;
                        _dbContext.Transactions.Add(transaction);
                        _dbContext.SaveChanges();
                        return "Deposit successful.";

                    }
                    else
                    {
                        var newvalue = label.CurrentAmount + amount;
                        if (newvalue <= label.DesiredAmount)
                        {
                            label.CurrentAmount = newvalue;
                            wallet.WalletBalance += amount;
                            _dbContext.Transactions.Add(transaction);
                            _dbContext.SaveChanges();
                            return "Deposit successful.";
                        }
                        else { return "the amount is more than label desiredamount"; };

                    }

                }
                return "blocked wallet!";
            }
            return "the wallet does not contain this label";

        }

        public List<TransactionDto> GetALLTransactions()
        {
            var transactions = _dbContext.Transactions.ToList();
            var transactionsDtos = _mapper.Map<List<TransactionDto>>(transactions);
            return transactionsDtos;
        }

        public TransactionDto GetTransaction(int transactionId)
        {
            var transaction = _dbContext.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);
            if (transaction == null)
            {
                throw new TransactionNotFoundException("transaction with ID {transactionId} not found", transactionId);
            }
            var transactionDto = _mapper.Map<TransactionDto>(transaction);
            return transactionDto;
        }

        public string Move(int sourceWalletId, int destWalletId, float amount)
        {
            var sourceWallet = _dbContext.Wallets.FirstOrDefault(w => w.WalletId == sourceWalletId);
            var destinationWallet = _dbContext.Wallets.FirstOrDefault(w => w.WalletId == destWalletId);

            if (sourceWallet == null || destinationWallet == null)
                return "Source or destination wallet not found.";
            else if (sourceWallet.IsBlocked == true || destinationWallet.IsBlocked == true)
                return "Blocked wallets";
            else if (sourceWallet.WalletBalance < amount)
                return "Insufficient balance in the source wallet.";

            // Create a new transaction for the source purse
            var sourceTransaction = new Transaction
            {
                TransactionType = TransactionType.withdraw,
                TransactionStatus = Status.successful,
                TransactionTime = DateTime.Now,
                TransactionValue = amount,
                Wallet = sourceWallet
            };

            // Create a new transaction for the destination purse
            var destinationTransaction = new Transaction
            {
                TransactionType = TransactionType.deposit,
                TransactionStatus = Status.successful,
                TransactionTime = DateTime.Now,
                TransactionValue = amount,
                Wallet = destinationWallet
            };

            // Update balances
            sourceWallet.WalletBalance -= amount;
            destinationWallet.WalletBalance += amount;

            // Save changes to the database
            _dbContext.Transactions.Add(sourceTransaction);
            _dbContext.Transactions.Add(destinationTransaction);
            _dbContext.SaveChanges();

            return "Money transfer successful.";
        }

        public string Withdraw(int walletId, float amount, string labelname)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(w => w.WalletId == walletId);
            var label = _dbContext.Labels.FirstOrDefault(l => l.WalletId == walletId && l.LabelName == labelname);
            if (wallet == null)
                return "wallet not found.";

           

            if (amount > wallet.WalletBalance) { return "withdraw amount more than wallet balance"; }

            
            else if (wallet.Labels.Contains(label) || label == null)
            {
                if (wallet.IsBlocked == false)
                {
                    var transaction = new Transaction
                    {
                        TransactionType = TransactionType.deposit,
                        TransactionStatus = Status.successful,
                        TransactionTime = DateTime.Now,
                        TransactionValue = amount,
                        Wallet = wallet,
                        Label = label
                    };
                    if (label == null)
                    {
                        wallet.WalletBalance -= amount;
                        _dbContext.Transactions.Add(transaction);
                        _dbContext.SaveChanges();
                        return "Deposit successful.";

                    }
                    else
                    {
                        var newvalue = label.CurrentAmount - amount;
                        if (newvalue >= 0)
                        {
                            label.CurrentAmount = newvalue;
                            wallet.WalletBalance -= amount;
                            _dbContext.Transactions.Add(transaction);
                            _dbContext.SaveChanges();
                            return "Deposit successful.";
                        }
                        else { return "not have sufficient label amount"; };

                    }

                }
                return "blocked wallet!";
            }
            return "the wallet does not contain this label";

        }
    }
}

    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException(string message, int id) : base(message) { }
    }



