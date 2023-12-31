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
    public class SMSNotificationConfig : IEntityTypeConfiguration<SMSNotification>
    {
        public void Configure(EntityTypeBuilder<SMSNotification> builder)
        {
            builder.ToTable("SMSNotification");
            builder.HasKey(x => x.NotifId);
            builder.Property(x => x.Phonenumber);
        }
    }
}
