using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;

namespace Wallet.Application.Contracts
{
    public interface IWallet
    {
        string CreateWallet(WalletEDto walletdto, int userId);
        string UpdateWallet(WalletEDto walletdto);
        string DeleteWallet(WalletEDto walletdto);
        List<WalletEDto> GetWallets();
        WalletEDto GetWallet(int userId);
        float GetBalance(int walletId);
        List<LabelDto> GetLabels(int walletId);

    }
}
