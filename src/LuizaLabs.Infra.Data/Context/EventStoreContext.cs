using LuizaLabs.Domain.Core.Events;
using LuizaLabs.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LuizaLabs.Infra.Data.Context
{
    public class EventStoreContext : DbContext
    {
        public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options) { }

        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
