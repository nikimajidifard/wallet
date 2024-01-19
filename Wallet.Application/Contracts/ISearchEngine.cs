using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;
using wallet.Domain.Enums;
using Wallet.Application.Services.Search;

namespace Wallet.Application.Contracts
{
    public interface ISearchEngine
    {
        TransactionSearch searchTransactionService();
        WalletSearch SearchWalletService();
        UserSearch UserSearchService();
        CompanySearch CompanySearchService();

    }
}
