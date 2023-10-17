using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class MedicineSaleConfiguration : IEntityTypeConfiguration<MedicineSale>
  {
     public void Configure(EntityTypeBuilder<MedicineSale> builder)
    {
        builder.ToTable("medicine_sale");

         builder.Property(p => p.Date)
        .IsRequired()
        .HasColumnType("date");

        builder.Property(p => p.Total)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Owner)
        .WithMany(p => p.MedicineSales)
        .HasForeignKey(p => p.OwnerIdFk);
         builder.HasData(
            new MedicineSale {Id =1, Date= DateOnly.Parse("2023-12-22"), OwnerIdFk = 1, Total = 15000}
        );
  }
  }