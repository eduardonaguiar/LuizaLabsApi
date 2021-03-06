﻿using LuizaLabs.Domain.Models;
using LuizaLabs.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LuizaLabs.Infra.Data.Context
{
    public class LuizaLabsContext : DbContext
    {

        public LuizaLabsContext(DbContextOptions<LuizaLabsContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new FavoritesMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}