using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
  {
     public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.ToTable("medicine");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Stock)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Price)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Laboratory)
        .WithMany(p => p.Medicines)
        .HasForeignKey(p => p.LaboratoryIdFk);

         builder.HasData(
            new Medicine {Id = 1, Name = "Amoxicilina", Stock = 100, Price = 12000, LaboratoryIdFk = 1},
            new Medicine {Id = 2, Name = "Gentamicina", Stock = 100, Price = 15000, LaboratoryIdFk = 1},
            new Medicine {Id = 3, Name = "Acetaminofen", Stock = 1003, Price = 50500, LaboratoryIdFk = 2}

        );
  }
  }