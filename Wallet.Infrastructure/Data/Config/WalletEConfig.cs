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
    public class WalletEConfig : IEntityTypeConfiguration<WalletE>
    {
        public void Configure(EntityTypeBuilder<WalletE> builder)
        {
            builder.ToTable("WalletE");
            builder.HasKey(x => x.WalletId);
            builder.Property(x => x.WalletBalance).HasDefaultValue(0.0);
            builder.Property(x => x.IsBlocked).HasDefaultValue(false);
        }
    }
}
