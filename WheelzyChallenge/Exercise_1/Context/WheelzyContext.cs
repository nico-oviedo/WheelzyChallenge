using Exercise_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_1.Context;

public partial class WheelzyContext : DbContext
{
    public WheelzyContext()
    {
    }

    public WheelzyContext(DbContextOptions<WheelzyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarQuote> CarQuotes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Make> Makes { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusHistory> StatusHistories { get; set; }

    public virtual DbSet<Submodel> Submodels { get; set; }

    public virtual DbSet<ZipCode> ZipCodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(local);Database=Wheelzy;User Id=sa;Password=sqldb;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Buyer__3214EC071CF15040");

            entity.ToTable("Buyer");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Car__3214EC07145C0A3F");

            entity.ToTable("Car");

            entity.Property(e => e.Year).HasMaxLength(4);

            entity.HasOne(d => d.Customer).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Car__CustomerId__164452B1");

            entity.HasOne(d => d.Make).WithMany(p => p.Cars)
                .HasForeignKey(d => d.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Car__MakeId__173876EA");

            entity.HasOne(d => d.Model).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Car__ModelId__182C9B23");

            entity.HasOne(d => d.Submodel).WithMany(p => p.Cars)
                .HasForeignKey(d => d.SubmodelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Car__SubmodelId__1920BF5C");

            entity.HasOne(d => d.ZipCode).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ZipCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Car__ZipCodeId__1A14E395");
        });

        modelBuilder.Entity<CarQuote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarQuote__3214EC072B3F6F97");

            entity.ToTable("CarQuote");

            entity.HasIndex(e => e.CarId, "UI_CarQuote_CarId_IsCurrent")
                .IsUnique()
                .HasFilter("([IsCurrent]=(1))");

            entity.HasOne(d => d.Buyer).WithMany(p => p.CarQuotes)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarQuote__BuyerI__2F10007B");

            entity.HasOne(d => d.Car).WithMany(p => p.CarQuotes)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarQuote__CarId__2E1BDC42");

            entity.HasOne(d => d.Status).WithMany(p => p.CarQuotes)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarQuote__Status__300424B4");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC070CBAE877");

            entity.ToTable("Customer");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Make>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Make__3214EC077F60ED59");

            entity.ToTable("Make");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Model__3214EC0703317E3D");

            entity.ToTable("Model");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Make).WithMany(p => p.Models)
                .HasForeignKey(d => d.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Model__MakeId__0519C6AF");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC07267ABA7A");

            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusHistory>(entity =>
        {
            entity.HasKey(e => new { e.CarQuoteId, e.StatusId }).HasName("PK__StatusHi__CC55154D32E0915F");

            entity.ToTable("StatusHistory");

            entity.Property(e => e.ChangedBy).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.CarQuote).WithMany(p => p.StatusHistories)
                .HasForeignKey(d => d.CarQuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StatusHis__CarQu__34C8D9D1");

            entity.HasOne(d => d.Status).WithMany(p => p.StatusHistories)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StatusHis__Statu__35BCFE0A");
        });

        modelBuilder.Entity<Submodel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Submodel__3214EC0707F6335A");

            entity.ToTable("Submodel");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Model).WithMany(p => p.Submodels)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Submodel__ModelI__09DE7BCC");
        });

        modelBuilder.Entity<ZipCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZipCode__3214EC07108B795B");

            entity.ToTable("ZipCode");

            entity.Property(e => e.Code).HasMaxLength(5);

            entity.HasMany(d => d.Buyers).WithMany(p => p.ZipCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "ZipCodeBuyer",
                    r => r.HasOne<Buyer>().WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ZipCode_B__Buyer__239E4DCF"),
                    l => l.HasOne<ZipCode>().WithMany()
                        .HasForeignKey("ZipCodeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ZipCode_B__ZipCo__22AA2996"),
                    j =>
                    {
                        j.HasKey("ZipCodeId", "BuyerId").HasName("PK__ZipCode___8266EF6B20C1E124");
                        j.ToTable("ZipCode_Buyer");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
