using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServicePlatform.Data.Models;

public partial class PlatformDbContext : DbContext
{
    public PlatformDbContext()
    {
    }

    public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Expert> Experts { get; set; }

    public virtual DbSet<Il> Ils { get; set; }

    public virtual DbSet<Ilce> Ilces { get; set; }

    public virtual DbSet<Mahalle> Mahalles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PlatformDb;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.HasOne(d => d.Il).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IlId)
                .HasConstraintName("FK_Address_Il");

            entity.HasOne(d => d.Ilce).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IlceId)
                .HasConstraintName("FK_Address_Ilce");

            entity.HasOne(d => d.Mahalle).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.MahalleId)
                .HasConstraintName("FK_Address_Mahalle");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Customer_Address");

            entity.HasOne(d => d.Role).WithMany(p => p.Customers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Customer_Role");
        });

        modelBuilder.Entity<Expert>(entity =>
        {
            entity.ToTable("Expert");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Address).WithMany(p => p.Experts)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Expert_Address");

            entity.HasOne(d => d.Role).WithMany(p => p.Experts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Expert_Role");

            entity.HasOne(d => d.Service).WithMany(p => p.Experts)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Expert_Service");
        });

        modelBuilder.Entity<Il>(entity =>
        {
            entity.ToTable("Il");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Ilce>(entity =>
        {
            entity.ToTable("Ilce");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Mahalle>(entity =>
        {
            entity.ToTable("Mahalle");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Transaction_Customer");

            entity.HasOne(d => d.Expert).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ExpertId)
                .HasConstraintName("FK_Transaction_Expert");

            entity.HasOne(d => d.Service).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Transaction_Service");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
