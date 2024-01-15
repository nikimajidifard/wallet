using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.DTOs
{
    public class LabelDto
    {
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public float DesiredAmount { get; set; }
        public float CurrentAmount { get; set; }
        public int WalletId { get; set; }
    }
}
