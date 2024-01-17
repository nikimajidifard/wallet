using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet.Domain.Entities
{
    public class Label
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public float DesiredAmount { get; set; }
        public float CurrentAmount { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public WalletE Wallet { get; set; }
        public int WalletId { get; set; }

    }
}
