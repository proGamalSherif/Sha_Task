using System.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace System.Infrastructure.Data;

public partial class SystemDBContext : DbContext
{
    public SystemDBContext()
    {
    }
    public SystemDBContext(DbContextOptions<SystemDBContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Branches> Branches { get; set; }
    public virtual DbSet<Cashier> Cashier { get; set; }
    public virtual DbSet<Cities> Cities { get; set; }
    public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
    public virtual DbSet<InvoiceHeader> InvoiceHeader { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branches>(entity =>
        {
            entity.Property(e => e.BranchName)
                .HasMaxLength(200)
                .HasDefaultValue("");

            entity.HasOne(d => d.City).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Branches_Cities");
        });
        modelBuilder.Entity<Cashier>(entity =>
        {
            entity.Property(e => e.CashierName)
                .HasMaxLength(200)
                .HasDefaultValue("");

            entity.HasOne(d => d.Branch).WithMany(p => p.Cashier)
                .HasForeignKey(d => d.BranchID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cashier_Branches");
        });
        modelBuilder.Entity<Cities>(entity =>
        {
            entity.Property(e => e.CityName)
                .HasMaxLength(200)
                .HasDefaultValue("");
        });
        modelBuilder.Entity<InvoiceDetails>(entity =>
        {
            entity.Property(e => e.ItemName)
                .HasMaxLength(200)
                .HasDefaultValue("");

            entity.HasOne(d => d.InvoiceHeader).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceHeaderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetails_InvoiceHeader");
        });
        modelBuilder.Entity<InvoiceHeader>(entity =>
        {
            entity.Property(e => e.CustomerName)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.Invoicedate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.InvoiceHeader)
                .HasForeignKey(d => d.BranchID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceHeader_Branches");

            entity.HasOne(d => d.Cashier).WithMany(p => p.InvoiceHeader)
                .HasForeignKey(d => d.CashierID)
                .HasConstraintName("FK_InvoiceHeader_Cashier");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
