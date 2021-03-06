﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Domain.Models;

namespace WebApp.Infrastructure.EntityTypes
{
    internal class CompanyEntityTypeConfiguration : BaseEntityTypeConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("CompanyID");

            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.Address);
            builder.Property(o => o.PhoneNumber);

            builder.HasIndex(i => i.Name).IsUnique().HasFilter("[IsDeleted] = 0");
            builder.HasIndex(i => i.Id).IsUnique().HasFilter("[IsDeleted] = 0");

            base.Configure(builder);
        }
    }
}