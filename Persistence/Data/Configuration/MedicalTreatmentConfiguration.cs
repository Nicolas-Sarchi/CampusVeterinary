using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class MedicalTreatmentConfiguration : IEntityTypeConfiguration<MedicalTreatment>
  {
     public void Configure(EntityTypeBuilder<MedicalTreatment> builder)
    {
        builder.ToTable("medical_treatment");

        builder.Property(p => p.Dose)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.AdministrationDate)
        .IsRequired().HasColumnType("date");

        builder.Property(p => p.Observation)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasOne(p => p.Appointment)
        .WithMany(p => p.MedicalTreatments)
        .HasForeignKey(p => p.AppointmentIdFk);

        builder.HasOne(p => p.Medicine)
        .WithMany(p => p.MedicalTreatments)
        .HasForeignKey(p => p.MedicineIdFk);
        
        builder.HasData(
            new MedicalTreatment {Id =1, AppointmentIdFk= 1, AdministrationDate= DateOnly.Parse("2023-10-12"), Dose = "12 mg", MedicineIdFk = 1, Observation = "Todo OK" }
        );
  }
  }