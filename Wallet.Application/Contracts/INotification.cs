using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;

namespace Wallet.Application.Contracts
{
    public interface INotification
    {
        string Notify(NotificationDto Notif, int transactionId, string message);
        NotificationDto GetNotification(int NotifId);
        List<NotificationDto> GetAllNotifications();
    }
}
