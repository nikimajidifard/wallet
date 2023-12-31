using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet.Domain.Entities;

namespace Wallet.Infrastructure.Data
{
    public class WalletDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WalletE> Wallets { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SMSNotification> SMSNotifications { get; set; }
        public DbSet<PushNotification> PushNotifications { get; set; }
        public DbSet<EmailNotification> EmailNotifications { get; set; }
        public DbSet<Label> Labels { get; set; }

    }
}
