using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

          builder.Property(p => p.Name)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.Property(p => p.Password)
           .HasColumnName("password")
           .HasColumnType("varchar")
           .HasMaxLength(255)
           .IsRequired();

            builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder
           .HasMany(p => p.Roles)
           .WithMany(r => r.Users)
           .UsingEntity<UserRole>(

               j => j
               .HasOne(pt => pt.Role)
               .WithMany(t => t.UsersRoles)
               .HasForeignKey(ut => ut.RoleIdFk),


               j => j
               .HasOne(et => et.User)
               .WithMany(et => et.UsersRoles)
               .HasForeignKey(el => el.UserIdFk),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.UserIdFk, t.RoleIdFk });

               });

            builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        }

    }
    