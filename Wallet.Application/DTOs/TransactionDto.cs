using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using wallet.Domain.Enums;

namespace Wallet.Application.DTOs
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public DateTime TransactionTime { get; set; }
        public float TransactionValue { get; set; }
        public int WalletId { get; set; }
    }
}
