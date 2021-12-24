using TrackATruckMgt.Core.DTOs;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Infrstructure.Configurations
{
    public class SeedingConfigurations : IEntityTypeConfiguration<DriverDto>
{
    public void Configure(EntityTypeBuilder<DriverDto> builder)
        {
            builder.ToTable("Drivers");
            builder.Property(s => s.CreatedAt)
                .IsRequired(true);
            builder.Property(s => s.DriverId)
                .HasDefaultValue(true);

            builder.HasData
            (
                new DriverDto
                {
                    Id = 1 /*Guid.NewGuid()*/,
                    Name = "John Doe",
                    CreatedAt = DateTime.Today,
                    DriverId = "TRs67",
                    EmployeeNumber = "Emo9821",
                    CreatedBy = "Engr Tee",
                    IsActive = true,
                    SiteId = "site456",
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = "John Doe"

                },
                new DriverDto
                {
                    Id = 2 /*Guid.NewGuid()*/,
                    Name = "Seun tyu",
                    CreatedAt = DateTime.Today,
                    DriverId = "TRs78",
                    EmployeeNumber = "Emo98671",
                    CreatedBy = "Engr Tee",
                    IsActive = true,
                    SiteId = "site456",
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = "Seun tyu"
                },
                new DriverDto
                {
                    Id = 3 /*Guid.NewGuid()*/,
                    Name = "John Otedola",
                    CreatedAt = DateTime.Today,
                    DriverId = "TRs90",
                    EmployeeNumber = "Emo021",
                    CreatedBy = "Engr Tee",
                    IsActive = true,
                    SiteId = "site460",
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = "John Otedola"
                }
            ) ;
        }
    }
}

