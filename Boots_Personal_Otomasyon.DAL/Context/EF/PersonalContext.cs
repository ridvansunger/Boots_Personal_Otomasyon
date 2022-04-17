using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Context.EF
{
    using Entities;
    using Configuration;
    public class PersonalContext : DbContext
    {

        //hata verdi startup üzerinden tanımladığımız parametre şeklinde verdik
        public PersonalContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Department> Department { get; set; }




        private bool IsMigration = false;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (IsMigration)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-TSR38CT\\MSSQLSERVER1;Database=PersonalDb; uid=sa; pwd=123;");
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }
    }
}
