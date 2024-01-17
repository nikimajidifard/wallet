using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet.Domain.Enums;

namespace wallet.Domain.Entities
{
    public class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NotifId { get; set; }
        public DateTime NotificationDate { get; set; }
        public NotificationType NotificationType{ get; set; }
        public string NotifMessage { get; set; }
        public Transaction Transaction { get; set; }
        public int TransactionId;
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
