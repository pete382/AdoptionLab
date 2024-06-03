using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdoptionLab.Models;

public partial class PetsContext : DbContext
{
    public PetsContext()
    {
    }

    public PetsContext(DbContextOptions<PetsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetCategory> PetCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=Pets; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pet__3213E83F91F176EB");

            entity.ToTable("Pet");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Breed).HasColumnName("breed");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(100)
                .HasColumnName("imagepath");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.BreedNavigation).WithMany(p => p.Pets)
                .HasForeignKey(d => d.Breed)
                .HasConstraintName("FK__Pet__breed__619B8048");
        });

        modelBuilder.Entity<PetCategory>(entity =>
        {
            entity.ToTable("PetCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Personality)
                .HasMaxLength(20)
                .HasColumnName("personality");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
