using LuizaLabs.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuizaLabs.Infra.Data.Mapping
{
    public class FavoritesMap : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder
                .HasOne(f => f.Customer)
                .WithMany(f => f.Favorites);

            builder.Property(c => c.Title)
                .HasColumnType("varchar(200)")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(c => c.Image)
                .HasColumnType("varchar(200)")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(c => c.Price)
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(c => c.ProductId)
                .HasColumnType("varchar(300)")
                .IsRequired();
        }
    }
}
