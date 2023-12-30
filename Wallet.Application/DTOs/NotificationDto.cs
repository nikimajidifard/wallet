using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.DTOs
{
    public class NotificationDto
    {
        public int NotifId { get; set; }
        public DateTime NotificationDate { get; set; }
        public string NotificationType { get; set; }
    }

    public class SMSNotificationDto : NotificationDto
    {
        public string Phonenumber { get; set; }

    }
    public class EmailNotificationDto : NotificationDto
    {
        public string Email { get; set; }
    }
    public class PushNotificationDto : NotificationDto
    {
        public string DeviceId { get; set; }
    }
}
