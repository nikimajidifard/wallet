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
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public Status TransactionStatus { get; set; }
        public DateTime TransactionTime { get; set; }
        public float TransactionValue { get; set; }
        public int WalletId { get; set; }
        public WalletE Wallet { get; set; }
        //public Notification Notification { get; set; }
        public Label? Label { get; set; }
        //public int NotificationId { get; set; } // Foreign key
    }
}
