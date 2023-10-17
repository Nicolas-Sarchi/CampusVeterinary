using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class PurchaseDetailConfiguration : IEntityTypeConfiguration<PurchaseDetail>
  {
     public void Configure(EntityTypeBuilder<PurchaseDetail> builder)
    {
        builder.ToTable("purchase_detail");

        builder.Property(p => p.Quantity)
        .IsRequired();

        builder.Property(p => p.Subtotal)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.MedicinePurchase)
        .WithMany(p => p.PurchaseDetails)
        .HasForeignKey(p => p.IdMedicinePurchaseFk);
        
        builder.HasOne(p => p.Medicine)
        .WithMany(p => p.PurchaseDetails)
        .HasForeignKey(p => p.MedicineIdFk);

        builder.HasData(
            new PurchaseDetail {Id = 1, IdMedicinePurchaseFk = 1, MedicineIdFk= 1, Quantity= 1, Subtotal = 12000}
        );
  }
  }