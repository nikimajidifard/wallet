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
        string CreateWallet(WalletEDto wallet, int UserId);
        string UpdateWallet(WalletEDto wallet,float NewBalance, int UserId);
        string DeleteWallet(WalletEDto wallet, int UserId);
        List<WalletEDto> GetWallets();
        WalletEDto GetWallet(int UserId);
        float GetBalance(int WalletId);
        List<LabelDto> Labels(int WalletId);

    }
}
