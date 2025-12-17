using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StundenplanDb.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Klassen> Klassens { get; set; }

    public virtual DbSet<Lehrer> Lehrers { get; set; }

    public virtual DbSet<StundenplanEintraege> StundenplanEintraeges { get; set; }

    public virtual DbSet<Zimmer> Zimmers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StundenplanDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Klassen>(entity =>
        {
            entity.HasKey(e => e.KlasseId).HasName("PK__Klassen__A8588F98B4DB8A91");

            entity.ToTable("Klassen");

            entity.HasIndex(e => e.Name, "UQ__Klassen__737584F62A7F6FF5").IsUnique();

            entity.Property(e => e.KlasseId).HasColumnName("KlasseID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Lehrer>(entity =>
        {
            entity.HasKey(e => e.LehrerId).HasName("PK__Lehrer__08F2AB50AB0DB9B3");

            entity.ToTable("Lehrer");

            entity.Property(e => e.LehrerId).HasColumnName("LehrerID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<StundenplanEintraege>(entity =>
        {
            entity.HasKey(e => e.EintragId).HasName("PK__Stundenp__C740BC292882E63D");

            entity.ToTable("StundenplanEintraege");

            entity.Property(e => e.EintragId).HasColumnName("EintragID");
            entity.Property(e => e.KlasseId).HasColumnName("KlasseID");
            entity.Property(e => e.LehrerId).HasColumnName("LehrerID");
            entity.Property(e => e.Uhrzeit).HasPrecision(0);
            entity.Property(e => e.ZimmerId).HasColumnName("ZimmerID");

            entity.HasOne(d => d.Klasse).WithMany(p => p.StundenplanEintraeges)
                .HasForeignKey(d => d.KlasseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stundenplan_Klassen");

            entity.HasOne(d => d.Lehrer).WithMany(p => p.StundenplanEintraeges)
                .HasForeignKey(d => d.LehrerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stundenplan_Lehrer");

            entity.HasOne(d => d.Zimmer).WithMany(p => p.StundenplanEintraeges)
                .HasForeignKey(d => d.ZimmerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stundenplan_Zimmer");
        });

        modelBuilder.Entity<Zimmer>(entity =>
        {
            entity.HasKey(e => e.ZimmerId).HasName("PK__Zimmer__B86BAFFA0F699ECF");

            entity.ToTable("Zimmer");

            entity.HasIndex(e => e.Bezeichnung, "UQ__Zimmer__8FB64A0A95F529AD").IsUnique();

            entity.Property(e => e.ZimmerId).HasColumnName("ZimmerID");
            entity.Property(e => e.Bezeichnung).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
