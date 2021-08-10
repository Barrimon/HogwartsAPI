using HogwartsCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsInfrastructure.Data.Configurations
{
    public class ApplicationForIncomeConfiguration : IEntityTypeConfiguration<ApplicationForIncome>
    {
        public void Configure(EntityTypeBuilder<ApplicationForIncome> builder)
        {
            builder.ToTable("Master_ApplicationForIncome");
            builder.HasKey(e => e.EntityCode);
        }
    }
}
