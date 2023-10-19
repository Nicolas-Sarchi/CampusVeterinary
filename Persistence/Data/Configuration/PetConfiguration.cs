using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class PetConfiguration : IEntityTypeConfiguration<Pet>
  {
     public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pet");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.BirthDate)
        .IsRequired()
        .HasColumnType("date");

        builder.HasOne(p => p.Owner)
        .WithMany(p => p.Pets)
        .HasForeignKey(p => p.OwnerIdFk);

        builder.HasOne(p => p.Breed)
        .WithMany(p => p.Pets)
        .HasForeignKey(p => p.BreedIdFk);

        builder.HasData(
            new Pet {Id = 1, Name = "Oliver", BirthDate = DateOnly.Parse("2016-04-20"), BreedIdFk = 2, OwnerIdFk = 1},
            new Pet {Id = 2, Name = "Paco", BirthDate = DateOnly.Parse("2020-03-12"), BreedIdFk = 1, OwnerIdFk = 1},
            new Pet {Id = 3, Name = "Michi", BirthDate = DateOnly.Parse("2019-09-21"), BreedIdFk = 3, OwnerIdFk = 2}
        );
  }}
  