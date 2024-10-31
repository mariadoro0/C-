using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PalazzoMadama.Models;

public partial class GalleriaArtePalazzoMadamaContext : DbContext
{
    public GalleriaArtePalazzoMadamaContext()
    {
    }

    public GalleriaArtePalazzoMadamaContext(DbContextOptions<GalleriaArtePalazzoMadamaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autori { get; set; }

    public virtual DbSet<Materiale> Materiali { get; set; }

    public virtual DbSet<Opera> Opere { get; set; }

    public virtual DbSet<VwElencoMateriali> VwElencoMateriali { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GalleriaArte-PalazzoMadama;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.ToTable("Autore");
        });

        modelBuilder.Entity<Materiale>(entity =>
        {
            entity.ToTable("Materiale");
        });

        modelBuilder.Entity<Opera>(entity =>
        {
            entity.ToTable("Opera");

            entity.Property(e => e.AmbitoCulturale).HasColumnName("Ambito_culturale");
            entity.Property(e => e.Lsreferenceby).HasColumnName("lsreferenceby");
            entity.Property(e => e.TitoloSoggetto).HasColumnName("Titolo_soggetto");

            entity.HasOne(d => d.IdAutoreNavigation).WithMany(p => p.Opere)
                .HasForeignKey(d => d.IdAutore)
                .HasConstraintName("FK_Opera_Autore");

            entity.HasMany(d => d.IdMateriales).WithMany(p => p.IdOperas)
                .UsingEntity<Dictionary<string, object>>(
                    "OperaMateriale",
                    r => r.HasOne<Materiale>().WithMany()
                        .HasForeignKey("IdMateriale")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OperaMateriale_Materiale"),
                    l => l.HasOne<Opera>().WithMany()
                        .HasForeignKey("IdOpera")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OperaMateriale_Opera"),
                    j =>
                    {
                        j.HasKey("IdOpera", "IdMateriale");
                        j.ToTable("OperaMateriale");
                    });
        });

        modelBuilder.Entity<VwElencoMateriali>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ElencoMateriali");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
