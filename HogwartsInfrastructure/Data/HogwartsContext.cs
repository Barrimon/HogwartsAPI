using System;
using System.Collections.Generic;
using System.Text;
using HogwartsCore.Entities;
using HogwartsInfrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HogwartsInfrastructure.Data
{
    public class HogwartsContext : DbContext
    {
        public HogwartsContext(DbContextOptions<HogwartsContext> options) : base(options){}

        public virtual DbSet<ApplicationForIncome> ApplicationForIncome { get; set; }
        public virtual DbSet<Fraternity> Fraternity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationForIncomeConfiguration());
            modelBuilder.ApplyConfiguration(new FraternityConfiguration());
        }
    }
}
