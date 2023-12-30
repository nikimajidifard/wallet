using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet.Domain.Entities
{
    public class Label
    {
        public string Name { get; set; }
        public float DesiredAmount { get; set; }
        public float CurrentAmount { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public Wallet Wallet { get; set; }

    }
}
