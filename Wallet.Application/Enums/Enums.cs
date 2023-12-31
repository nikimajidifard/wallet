using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Enums
{
    public enum TransactionType
    {
        withdraw,
        deposit
    }
    public enum Status
    {
        None,
        pending,
        successful,
        canceled
    }

    public enum WalletType
    {
        Major,
        Minor
    }

    public enum NotificationType
    {
        purchase,
        move,
        withdraw,
        deposit        
    }

}
