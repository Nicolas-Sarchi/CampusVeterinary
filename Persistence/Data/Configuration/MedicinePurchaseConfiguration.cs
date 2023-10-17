using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class MedicinePurchaseConfiguration : IEntityTypeConfiguration<MedicinePurchase>
  {
     public void Configure(EntityTypeBuilder<MedicinePurchase> builder)
    {
        builder.ToTable("medicine_purchase");

        builder.Property(p => p.Date)
        .IsRequired()
        .HasColumnType("date");

        builder.Property(p => p.Total)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Supplier)
        .WithMany(p => p.MedicinePurchases)
        .HasForeignKey(p => p.SupplierIdFk);

        builder.HasData(
            new MedicinePurchase {Id =1, Date= DateOnly.Parse("2023-12-22"), SupplierIdFk = 1, Total = 12000}
        );
  }
  }