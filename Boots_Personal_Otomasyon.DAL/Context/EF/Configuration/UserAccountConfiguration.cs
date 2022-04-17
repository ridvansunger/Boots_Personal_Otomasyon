
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Context.EF.Configuration
{
    using Boots_Personal_Otomasyon.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasKey(t0 => t0.Id);
            builder.Property(t0 => t0.UserName).HasMaxLength(255).IsRequired();
            builder.Property(t0 => t0.Password).HasMaxLength(100).IsRequired();
            builder.Property(t0 => t0.FullName).HasMaxLength(255);
        }
    }
}
