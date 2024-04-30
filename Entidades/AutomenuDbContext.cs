using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class AutomenuDbContext : DbContext
{
    public AutomenuDbContext()
    {
    }

    public AutomenuDbContext(DbContextOptions<AutomenuDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=Automenu_DB;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

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
            entity.HasKey(e => e.Cnpj).HasName("PRIMARY");

            entity.ToTable("restaurant");

            entity.HasIndex(e => e.FkAddressId, "Fk_Address_Id");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("CNPJ");
            entity.Property(e => e.Email).HasMaxLength(50);
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
