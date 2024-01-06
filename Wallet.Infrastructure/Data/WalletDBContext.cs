using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet.Domain.Entities;
using Wallet.Infrastructure.Data.Config;

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
        public DbSet<Voucher> Vouchers { get; set; }
        public WalletDBContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // to identify to db our configurations
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new WalletEConfig());
            modelBuilder.ApplyConfiguration(new CompanyConfig());
            modelBuilder.ApplyConfiguration(new TransactionConfig());
            modelBuilder.ApplyConfiguration(new NotificationConfig());
            modelBuilder.ApplyConfiguration(new SMSNotificationConfig());
            modelBuilder.ApplyConfiguration(new PushNotificationConfig());
            modelBuilder.ApplyConfiguration(new EmailNotificationConfig());
            modelBuilder.ApplyConfiguration(new LabelConfig());
            modelBuilder.ApplyConfiguration(new VoucherConfig());
        }
        public class BloggingContextFactory : IDesignTimeDbContextFactory<WalletDBContext>
        {
            public WalletDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<WalletDBContext>();
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-CMR9S4V;Database=DemoDb;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
                return new WalletDBContext(optionsBuilder.Options);

            }
       
        }

    }
}