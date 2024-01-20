using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet.Domain.Enums;

namespace Wallet.Application.DTOs
{
    public class WalletEDto
    {
        public int WalletId { get; set; }
        public float WalletBalance { get; set; }
        public WalletType WalletType { get; set; }
        public bool IsBlocked { get; set; }
        public int UserId { get; set; }
    }
}
