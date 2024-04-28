using Microsoft.EntityFrameworkCore;

namespace Entidades;

public partial class AutomenuDbContext : DbContext
{
    public AutomenuDbContext()
    {
    }

    public AutomenuDbContext(DbContextOptions<AutomenuDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Restaurante> Restaurantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=Automenu_DB;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("PRIMARY");

            entity.ToTable("endereco");

            entity.Property(e => e.IdEndereco).HasColumnName("Id_endereco");
            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .HasColumnName("bairro");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .HasColumnName("cidade");
            entity.Property(e => e.Complemento)
                .HasMaxLength(100)
                .HasColumnName("complemento");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(100)
                .HasColumnName("logradouro");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("uf");
        });

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.Cnpj).HasName("PRIMARY");

            entity.ToTable("restaurante");

            entity.HasIndex(e => e.FkIdEndereco, "Fk_Id_endereco");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FkIdEndereco).HasColumnName("Fk_Id_endereco");
            entity.Property(e => e.HashSenha)
                .HasMaxLength(255)
                .HasColumnName("Hash_senha");
            entity.Property(e => e.Nome).HasMaxLength(80);

            entity.HasOne(d => d.FkIdEnderecoNavigation).WithMany(p => p.Restaurantes)
                .HasForeignKey(d => d.FkIdEndereco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("restaurante_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
