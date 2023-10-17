using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("appointment");

        builder.Property(p => p.Date)
        .IsRequired()
        .HasColumnType("date");

        builder.Property(p => p.Reason)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasOne(p => p.Pet)
        .WithMany(p => p.Appointments)
        .HasForeignKey(p => p.PetIdFk);

        builder.HasOne(p => p.Vet)
        .WithMany(p => p.Appointments)
        .HasForeignKey(p => p.VetIdFk);

        builder.HasData(
            new Appointment {Id =1, Date = DateOnly.Parse("2023-03-12"), Time= TimeOnly.Parse("10:30:00") ,PetIdFk = 2, Reason= "vacunacion", VetIdFk=1}
        );
    }
}