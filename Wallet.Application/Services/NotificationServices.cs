using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using Wallet.Infrastructure.Data;
using wallet.Domain.Entities;

namespace Wallet.Application.Services
{
    public class NotificationServices : INotification
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;
        public NotificationServices(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public string Notify(NotificationDto Notifdto, int transactionId, string message)
        {
            var transaction = _dbContext.Transactions.FirstOrDefault(t => t.TransactionID == transactionId);
            if (transaction == null) { return "transaction not found"; }
            var notification = _mapper.Map<Notification>(Notifdto);
            notification.Transaction = transaction;
            notification.TransactionId = transactionId;
            notification.NotifMessage = message;
            _dbContext.Add(notification);
            _dbContext.SaveChanges();
            return "notification was created";
        }
        public List<NotificationDto> GetAllNotifications()
        {
            var Notifications = _dbContext.Notifications.ToList();
            var NotificationsDtos = _mapper.Map<List<NotificationDto>>(Notifications);
            return NotificationsDtos;

        }

        public NotificationDto GetNotification(int NotifId)
        {
            var notification = _dbContext.Notifications.FirstOrDefault(v => v.NotifId == NotifId);
            if (notification == null)
            {
                throw new NotificationNotFoundException("Notification with ID {NotifId} not found", NotifId);
            }
            notification.NotifId = NotifId;
            var notificationdto = _mapper.Map<NotificationDto>(notification);
            return notificationdto;
        }


    }
    public class NotificationNotFoundException : Exception
    {
        public NotificationNotFoundException(string message, int id) : base(message) { }
    }
}
