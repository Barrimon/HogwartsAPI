using HogwartsCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsInfrastructure.Data.Configurations
{
    public class FraternityConfiguration : IEntityTypeConfiguration<Fraternity>
    {
        public void Configure(EntityTypeBuilder<Fraternity> builder)
        {
            builder.ToTable("Master_Fraternity");
            builder.HasKey(e => e.EntityCode);
        }
    }
}
