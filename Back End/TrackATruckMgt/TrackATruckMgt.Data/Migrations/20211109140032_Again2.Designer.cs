

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using TrackATruckMgt.Data;

namespace TrackAtruck.TruckingMgt.Data.Migrations
{
    [DbContext(typeof(APPContext))]
    [Migration("20211109140032_Again2")]
    partial class Again2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LaFarge.TruckingMgt.Data.Entities.Driver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("True");

                    b.Property<string>("EmployeeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            CreatedBy = "Engr Tee",
                            DriverId = "TRs67",
                            EmployeeNumber = "Emo9821",
                            IsActive = true,
                            Name = "John Doe",
                            SiteId = "site456",
                            UpdatedAt = new DateTime(2021, 11, 9, 6, 0, 31, 567, DateTimeKind.Local).AddTicks(3521),
                            UpdatedBy = "John Doe"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            CreatedBy = "Engr Tee",
                            DriverId = "TRs78",
                            EmployeeNumber = "Emo98671",
                            IsActive = true,
                            Name = "Seun tyu",
                            SiteId = "site456",
                            UpdatedAt = new DateTime(2021, 11, 9, 6, 0, 31, 567, DateTimeKind.Local).AddTicks(5586),
                            UpdatedBy = "Seun tyu"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            CreatedBy = "Engr Tee",
                            DriverId = "TRs90",
                            EmployeeNumber = "Emo021",
                            IsActive = true,
                            Name = "John Otedola",
                            SiteId = "site460",
                            UpdatedAt = new DateTime(2021, 11, 9, 6, 0, 31, 567, DateTimeKind.Local).AddTicks(5599),
                            UpdatedBy = "John Otedola"
                        });
                });

            modelBuilder.Entity("LaFarge.TruckingMgt.Data.Entities.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AgeOfReadingSeconds")
                        .HasColumnType("bigint");

                    b.Property<string>("AltitudeMetres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hdop")
                        .HasColumnType("int");

                    b.Property<int>("Heading")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvl")
                        .HasColumnType("bit");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OdometerKilometres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pdop")
                        .HasColumnType("int");

                    b.Property<string>("PositionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Source")
                        .HasColumnType("int");

                    b.Property<int>("SpeedKilometresPerHour")
                        .HasColumnType("int");

                    b.Property<int>("SpeedLimit")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vdop")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("LaFarge.TruckingMgt.Data.Entities.Truck", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssetId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastPositionTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trucks");
                });
#pragma warning restore 612, 618
        }
    }
}
