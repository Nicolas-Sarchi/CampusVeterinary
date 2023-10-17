using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
  {
     public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new Species {Id = 1, Name = "Canino"},
            new Species {Id = 2, Name = "Felino"}
        );
  }
  }