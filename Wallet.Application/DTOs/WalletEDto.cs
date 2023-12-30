using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.DTOs
{
    internal class WalletDto
    {
        public int WalletId { get; set; }
        public float WalletBalance { get; set; }
        public string WalletType { get; set; }
        public bool IsBlocked { get; set; }
        public int UserId { get; set; }
    }
}
