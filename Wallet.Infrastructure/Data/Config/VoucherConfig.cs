using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallet.Domain.Entities;

namespace Wallet.Infrastructure.Data.Config
{
    internal class VoucherConfig : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("voucher");
            builder.HasKey(x => x.VoucherId);
            builder.Property(x => x.VoucherAmount).HasDefaultValue(0.0);
        }
    }
}
