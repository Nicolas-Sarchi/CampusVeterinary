using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
  {
     public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.ToTable("Specialization");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);
        builder.HasData(
            new Specialization {Id = 1, Name = "Cirujia Vascular" },
            new Specialization {Id = 2, Name = "Cardiologia" }
        );
  }
  }