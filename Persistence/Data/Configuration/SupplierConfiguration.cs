using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
  {
     public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("supplier");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Address)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Phone)
        .IsRequired()
        .HasMaxLength(20);
        
        builder.HasData(
            new Supplier {Id = 1, Name = "UNIONAGRO S A",  Address = "Calle 12 # 12 -43", Phone = "12323"},
            new Supplier {Id = 2, Name = "Pet Pharma", Address = "Calle 12 # 12 -43", Phone = "12323"}
        );
  }
  }