using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet.Domain.Enums;


namespace wallet.Domain.Entities
{
    public class WalletE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WalletId { get; set; }
        public float WalletBalance { get; set; }
        public WalletType WalletType { get; set; }
        public bool IsBlocked { get; set; }
        public IEnumerable<Label> Labels { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Voucher> Vouchers { get; set; }
    }
}
