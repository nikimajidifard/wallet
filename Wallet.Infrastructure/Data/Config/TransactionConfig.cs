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
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(x => x.TransactionId);
            builder.Property(x => x.TransactionType).HasMaxLength(100);
            builder.Property(x => x.TransactionStatus).HasMaxLength(100);
            builder.Property(x => x.TransactionValue).HasMaxLength(100);
            builder.Property(x => x.TransactionTime);
            builder.HasOne(x => x.Notification)
             .WithOne(x => x.Transaction)
             .HasForeignKey<Transaction>(x => x.NotificationId)
             .IsRequired(false);

            builder.HasOne(x => x.Wallet)
      .WithMany(x => x.Transactions)
      .HasForeignKey(x => x.WalletId)
      .IsRequired()
      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
    