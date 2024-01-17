using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using wallet.Domain.Entities;

namespace Wallet.Infrastructure.Data.Config
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notification");
            builder.HasKey(x => x.NotifId);
            builder.Property(x => x.NotificationType);
            builder.Property(x => x.NotificationDate);
            // Configure the one-to-one relationship with Transaction
            /*builder.HasOne(x => x.Transaction)
                .WithOne(x => x.Notification)
                .HasForeignKey<Transaction>(x => x.NotificationId)
                .IsRequired(false);*/
        }

    }
}
