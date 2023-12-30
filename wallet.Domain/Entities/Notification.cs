using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet.Domain.Enums;

namespace wallet.Domain.Entities
{
    public class Notification
    {
        public int NotifId { get; set; }
        public DateTime NotificationDate { get; set; }
        public NotificationType NotificationType{ get; set; }
        public Transaction Transaction { get; set; }



    }
    public class SMSNotification: Notification
    {
        public string Phonenumber { get; set; }

    }
    public class EmailNotification: Notification
    {
        public string Email { get; set; }
    }
    public class PushNotification: Notification
    {
        public string DeviceId { get; set; }
    }
}
