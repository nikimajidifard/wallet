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
        string CreateVoucher(VoucherDto voucher, int voucherDest, int voucherSource);
        string UpdateWallet(WalletEDto wallet, float newAmount, DateTime newDate);
        string DeleteWallet(WalletEDto wallet);
        List<WalletEDto> GetWallets();
        WalletEDto GetWallet(int userId);
    }
}
