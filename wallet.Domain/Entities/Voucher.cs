﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet.Domain.Enums;

namespace wallet.Domain.Entities
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public int SourceVoucherId { get; set;}
        public int DestVoucherId { get; set; }
        public DateTime VoucherDate { get; set; }
        public Status VoucherStatus { get; set; }
        public float VoucherAmount { get; set; }
        public WalletE Wallet { get; set; }

    }
}
