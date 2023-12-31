using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;

namespace Wallet.Application.Services
{
    public class WalletServices : IWallet
    {
        public string CreateWallet(WalletEDto wallet, int UserId)
        {
            throw new NotImplementedException();
        }

        public string DeleteWallet(WalletEDto wallet, int UserId)
        {
            throw new NotImplementedException();
        }

        public float GetBalance(int WalletId)
        {
            throw new NotImplementedException();
        }

        public WalletEDto GetWallet(int UserId)
        {
            throw new NotImplementedException();
        }

        public List<WalletEDto> GetWallets()
        {
            throw new NotImplementedException();
        }

        public List<LabelDto> Labels(int WalletId)
        {
            throw new NotImplementedException();
        }

        public string UpdateWallet(WalletEDto wallet, float NewBalance, int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
