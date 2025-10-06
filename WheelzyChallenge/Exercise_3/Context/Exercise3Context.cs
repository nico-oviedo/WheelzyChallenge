using Exercise_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_3.Context;

public partial class Exercise3Context : DbContext
{
    public Exercise3Context()
    {
    }

    public Exercise3Context(DbContextOptions<Exercise3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(local);Database=Exercise3;User Id=sa;Password=sqldb;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC077F60ED59");

            entity.ToTable("Customer");

            entity.Property(e => e.Balance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__3214EC0703317E3D");

            entity.ToTable("Invoice");

            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__Custome__0519C6AF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
