﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;

namespace Wallet.Application.Contracts
{
    public interface ITransaction
    {
        string Deposit(int walletId, float amount,LabelDto labeldto);
        string Withdraw(int walletId, float amount, LabelDto labeldto);
        string Move(int sourceWalletId, int destWalletId, float amount);
        List<TransactionDto> GetALLTransactions();
        TransactionDto GetTransaction(int transactionId);
    }
}
