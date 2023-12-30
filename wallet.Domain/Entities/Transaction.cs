using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet.Domain.Enums;


namespace wallet.Domain.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public TransactionType TransactionKind { get; set; }
        public Status TransactionStatus { get; set; }
        public DateTime TransactionTime { get; set; }
        public float TransactionValue { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public Notification Notification { get; set; }
        public Label Label { get; set; }
    }
}
