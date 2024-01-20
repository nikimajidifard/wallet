﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;
using wallet.Domain.Enums;

namespace Wallet.Application.Contracts
{
    public interface ISearchWalletE
    {
        WalletEDto GetWalletbyId(int WalletID);
        List<WalletEDto> GetWalletbyUserId(int UserID);
        List<WalletEDto> GetWalletbyBalance(float WalletBalance);
        List<WalletEDto> GetWalletbyState(bool State);
    }
}
