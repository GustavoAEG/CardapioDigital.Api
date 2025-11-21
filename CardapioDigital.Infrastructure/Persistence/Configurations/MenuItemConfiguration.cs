using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Infrastructure.Persistence.Configurations;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("MenuItem");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
               .HasMaxLength(120)
               .IsRequired();

        builder.Property(m => m.Description)
               .HasMaxLength(800);

        builder.Property(m => m.PhotoUrl)
               .HasMaxLength(300);

        builder.Property(m => m.Tags)
               .HasMaxLength(200);

        builder.Property(m => m.Price)
               .HasPrecision(10, 2)
               .IsRequired();

        // 🔥 AQUI ESTÁ O SEGREDO DO ERRO
        builder.HasOne(m => m.Category)
               .WithMany(c => c.MenuItems)
               .HasForeignKey(m => m.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Restaurant)
               .WithMany(r => r.MenuItems)
               .HasForeignKey(m => m.RestaurantId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => new { m.RestaurantId, m.CategoryId, m.IsActive, m.Name });
    }
}
