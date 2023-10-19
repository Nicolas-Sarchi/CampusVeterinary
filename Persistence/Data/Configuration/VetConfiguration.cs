using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class VetConfiguration : IEntityTypeConfiguration<Vet>
  {
     public void Configure(EntityTypeBuilder<Vet> builder)
    {
        builder.ToTable("Veterinarian");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Phone)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasOne(p => p.Specialization)
        .WithMany(p => p.Vets)
        .HasForeignKey(p => p.SpecializationIdFk);

        builder.HasData(
            new Vet {Id =1, Email = "adas@qw", Name = "Juan", Phone = "12332", SpecializationIdFk= 1},
            new Vet {Id =2, Email = "erfdc@qdfw", Name = "Pedro", Phone = "555555", SpecializationIdFk= 2}

        );
      }  }