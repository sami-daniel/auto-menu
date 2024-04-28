﻿using Microsoft.EntityFrameworkCore;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
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

            entity.Property(e => e.IdEndereco).HasColumnName("ID_endereco");
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
                .HasColumnName("UF");
        });

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.Cnpj).HasName("PRIMARY");

            entity.ToTable("restaurante");

            entity.HasIndex(e => e.FkIdEndereco, "Fk_Id_endereco");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnName("CNPJ");
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
