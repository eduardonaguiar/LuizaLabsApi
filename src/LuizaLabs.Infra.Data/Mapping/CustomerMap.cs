﻿using LuizaLabs.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuizaLabs.Infra.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(c => c.Id)
                .HasColumnName("Id");

            builder
                .HasMany(c => c.Favorites)
                .WithOne(c => c.Customer)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
