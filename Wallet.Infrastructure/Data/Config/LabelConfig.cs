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
    public class LabelConfig : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("Label");
            builder.HasKey(x => x.LabelId);
            builder.Property(x => x.LabelName).HasMaxLength(150);
            builder.Property(x => x.DesiredAmount).HasMaxLength(100);
            builder.Property(x => x.CurrentAmount).HasMaxLength(100);
        }
    }
}
