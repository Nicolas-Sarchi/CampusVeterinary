using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class LaboratoryConfiguration : IEntityTypeConfiguration<Laboratory>
  {
     public void Configure(EntityTypeBuilder<Laboratory> builder)
    {
        builder.ToTable("laboratory");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Phone)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(p => p.Address)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasData(
            new Laboratory {Id = 1, Address = "Calle 23 # 23-34", Name = "Genfar", Phone=  "31311"}
          );
  }
  }