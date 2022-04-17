using Boots_Personal_Otomasyon.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Context.EF.Configuration
{
    class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.DepartmentName).HasMaxLength(255);
            builder.HasMany<Personal>(t0 => t0.Personals).WithOne(t1 => t1.Department).HasForeignKey(t1 => t1.DepartMentId);
            
        }
    }
}
