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
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");
            builder.HasKey(x => x.CompanyId);
            builder.Property(x => x.CompanyName).HasMaxLength(50);
            builder.Property(x => x.CompanyLocation).HasMaxLength(150);
            builder.Property(x => x.CompinyNo).HasMaxLength(20);
            builder.Property(x => x.CompanyRate).HasDefaultValue(0);
        }
    }
}
