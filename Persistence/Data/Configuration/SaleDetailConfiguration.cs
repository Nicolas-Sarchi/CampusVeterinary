using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
  {
     public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.ToTable("sale_detail");

        builder.Property(p => p.Quantity)
        .IsRequired();

        builder.Property(p => p.Subtotal)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.MedicineSale)
        .WithMany(p => p.SaleDetails)
        .HasForeignKey(p => p.IdMedicineSaleFk);
        
        builder.HasOne(p => p.Medicine)
        .WithMany(p => p.SaleDetails)
        .HasForeignKey(p => p.MedicineIdFk);
        builder.HasData(
            new SaleDetail {Id = 1, IdMedicineSaleFk = 1, MedicineIdFk= 2, Quantity= 1, Subtotal = 15000}
        );
  }
  }