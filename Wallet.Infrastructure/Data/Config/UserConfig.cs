using Microsoft.EntityFrameworkCore;
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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserName).HasMaxLength(150);
            builder.Property(x => x.UserRole).HasMaxLength(150);
            builder.Property(x => x.UserPhone).HasMaxLength(15);
        }
    }
}
