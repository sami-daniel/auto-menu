using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class AutoMenuDbContext : DbContext
{
    public AutoMenuDbContext(DbContextOptions<AutoMenuDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("PRIMARY");

            entity.ToTable("address");

            entity.Property(e => e.IdAddress).HasColumnName("ID_Address");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Complement).HasMaxLength(100);
            entity.Property(e => e.District).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(100);
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("UF");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.IdRestaurant).HasName("PRIMARY");

            entity.ToTable("restaurant");

            entity.HasIndex(e => e.FkAddressId, "Fk_Address_Id");

            entity.Property(e => e.IdRestaurant).HasColumnName("ID_Restaurant");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("CNPJ");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FkAddressId).HasColumnName("Fk_Address_Id");
            entity.Property(e => e.Name).HasMaxLength(80);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("Password_Hash");

            entity.HasOne(d => d.FkAddress).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.FkAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("restaurant_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
