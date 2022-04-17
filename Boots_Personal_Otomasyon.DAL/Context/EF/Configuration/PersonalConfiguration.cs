using Boots_Personal_Otomasyon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boots_Personal_Otomasyon.DAL.Context.EF.Configuration
{


    public class PersonalConfiguration : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.HasKey(t0 => t0.Id);
            builder.Property(t0 => t0.Twitter).HasMaxLength(500);
            builder.Property(t0 => t0.Linkedlin).HasMaxLength(500);
            builder.Property(t0 => t0.FaceBook).HasMaxLength(500);
            builder.Property(t0 => t0.Address).HasMaxLength(2000);
            builder.Property(t0 => t0.NameANdSurname).HasMaxLength(255).IsRequired();
            builder.Property(t => t.Email).HasMaxLength(255);
            builder.Property(t => t.Phone).HasMaxLength(50);
        }
    }
}
