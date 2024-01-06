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
        string CreateWallet(WalletEDto wallet, int userId);
        string UpdateWallet(WalletEDto wallet,float newBalance, int userId);
        string DeleteWallet(WalletEDto wallet, int userId);
        List<WalletEDto> GetWallets();
        WalletEDto GetWallet(int userId);
        float GetBalance(int walletId);
        List<LabelDto> Labels(int walletId);

    }
}
