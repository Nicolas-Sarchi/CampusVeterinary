using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
  {
     public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("owner");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(50);
        builder.Property(p => p.Phone)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasData(
            new Owner {Id = 1, Name = "Nicolas", Email = "nicolas@google.com", Phone = "12321"},
            new Owner {Id = 2, Name = "ROberto", Email = "rob@google.com", Phone = "666666"}

        );
  }
  }