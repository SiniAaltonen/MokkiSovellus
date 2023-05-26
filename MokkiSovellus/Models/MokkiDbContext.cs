using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MokkiSovellus.Models;

public partial class MokkiDbContext : DbContext
{
    public MokkiDbContext()
    {
    }

    public MokkiDbContext(DbContextOptions<MokkiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Work> Works { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Season__3214EC27FF87F37F");

            entity.ToTable("Season");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Season1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Season");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC274F1B2A8C");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Status1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Status");
        });

        modelBuilder.Entity<Work>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Work__3214EC2784CBC56A");

            entity.ToTable("Work");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Equipment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            entity.Property(e => e.WhenDuration)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.WorkName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.WorkStatus).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Season).WithMany(p => p.Works)
                .HasForeignKey(d => d.SeasonId)
                .HasConstraintName("FK__Work__SeasonID__73BA3083");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
