using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AnagraficaAPI.Models;

public partial class AnagraficaContext : DbContext
{
    public AnagraficaContext()
    {
    }

    public AnagraficaContext(DbContextOptions<AnagraficaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Studente> Studenti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Studente>(entity =>
        {
            entity.HasKey(e => e.Matricola).HasName("PK_StudentiITS");

            entity.ToTable("Studenti");

            entity.Property(e => e.Matricola).ValueGeneratedNever();
            entity.Property(e => e.Cap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Citta).HasMaxLength(50);
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.DataNascita).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LuogoNascita).HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.SiglaProvincia).HasMaxLength(50);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TitoloStudio).HasMaxLength(50);
            entity.Property(e => e.Via).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
