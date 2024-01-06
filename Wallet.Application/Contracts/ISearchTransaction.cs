using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;
using wallet.Domain.Enums;

namespace Wallet.Application.Contracts
{
    public interface ISearchTransaction
    {
        TransactionDto GetTransactionbyId(int transactionID);
        List<TransactionDto> GetTransactionbyType(TransactionType TransactionType);
        List<TransactionDto> GetTransactionbyTime(DateTime TransactionTime);
        List<TransactionDto> GetTransactionbyValue(float TransactionValue);
        List<TransactionDto> GetTransactionbyWallet(int walletID);
        List<TransactionDto> GetTransactionbyWalletStatus(Status status);
    }
}
