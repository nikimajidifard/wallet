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
    public class PushNotificationConfig : IEntityTypeConfiguration<PushNotification>
    {
        public void Configure(EntityTypeBuilder<PushNotification> builder)
        {
            builder.ToTable("PushNotification");
            builder.Property(x => x.DeviceId);
        }
    }
}
