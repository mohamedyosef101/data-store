using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace data_store.Models;

public partial class DataStoreContext : DbContext
{
    public DataStoreContext()
    {
    }

    public DataStoreContext(DbContextOptions<DataStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=MOHAMED-YOSEF;Initial Catalog=DATA_Store;Integrated Security=True; TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.ImgUrl)
                .HasColumnType("text")
                .HasColumnName("imgURL");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.ImgUrl)
                .HasColumnType("text")
                .HasColumnName("imgURL");
            entity.Property(e => e.Info)
                .HasMaxLength(225)
                .HasColumnName("info");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projects_Category");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Details)
                .HasMaxLength(300)
                .HasColumnName("details");
            entity.Property(e => e.Icon)
                .HasColumnType("text")
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("job_title");
            entity.Property(e => e.PersonImg)
                .HasColumnType("text")
                .HasColumnName("person_img");
            entity.Property(e => e.PersonName)
                .HasMaxLength(50)
                .HasColumnName("person_name");
            entity.Property(e => e.Quote)
                .HasMaxLength(600)
                .HasColumnName("quote");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
