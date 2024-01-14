using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;

namespace Wallet.Application.Contracts
{
    public interface IVoucher
    {
        string CreateVoucher(VoucherDto voucherdto, int voucherDest, int walletId);
        string UpdateVoucher(VoucherDto voucherdto);
        string DeleteVoucher(int voucherId);
        List<VoucherDto> GetVouchers();
        VoucherDto GetVoucher(int voucherId);
    }
}
