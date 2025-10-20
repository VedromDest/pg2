using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TreinAbonnementen.Persistence;

public partial class TrainSubsDbContext : DbContext
{
    public TrainSubsDbContext()
    {
    }

    public TrainSubsDbContext(DbContextOptions<TrainSubsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Email, "UK_Klant").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Station");

            entity.HasIndex(e => e.Name, "UK_Station").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Subscription");

            entity.HasIndex(e => e.CustomerId, "FK_Abonnement_Klant");

            entity.HasIndex(e => e.Station2Id, "FK_Abonnement_StationNaar");

            entity.HasIndex(e => e.Station1Id, "FK_Abonnement_StationVan");

            entity.Property(e => e.ComfortLevel).HasDefaultValueSql("'2'");
            entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            entity.Property(e => e.ValidTo).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Abonnement_Klant");

            entity.HasOne(d => d.Station1).WithMany(p => p.SubscriptionStation1s)
                .HasForeignKey(d => d.Station1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Abonnement_StationVan");

            entity.HasOne(d => d.Station2).WithMany(p => p.SubscriptionStation2s)
                .HasForeignKey(d => d.Station2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Abonnement_StationNaar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
