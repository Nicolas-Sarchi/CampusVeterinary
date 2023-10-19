using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class BreedConfiguration : IEntityTypeConfiguration<Breed>
  {
     public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("breed");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Species)
        .WithMany(p => p.Breeds)
        .HasForeignKey(p => p.SpeciesIdFk);

        builder.HasData(
            new Breed {Id = 1, Name = "Golden Retriever", SpeciesIdFk= 1},
            new Breed {Id = 2, Name = "Cocker Spaniel", SpeciesIdFk= 1},
            new Breed {Id = 3, Name = "Persian", SpeciesIdFk= 2}
        );
  }
  }