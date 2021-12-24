using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaFarge.TruckingMgt.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverId = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "True"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeOfReadingSeconds = table.Column<long>(type: "bigint", nullable: false),
                    AssetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltitudeMetres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heading = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvl = table.Column<bool>(type: "bit", nullable: false),
                    OdometerKilometres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hdop = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pdop = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    SpeedKilometresPerHour = table.Column<int>(type: "int", nullable: false),
                    SpeedLimit = table.Column<int>(type: "int", nullable: false),
                    Vdop = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPositionTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DriverId", "EmployeeNumber", "IsActive", "Name", "SiteId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1L, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "Engr Tee", "TRs67", "Emo9821", true, "John Doe", "site456", new DateTime(2021, 11, 15, 2, 44, 38, 797, DateTimeKind.Local).AddTicks(5774), "John Doe" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DriverId", "EmployeeNumber", "IsActive", "Name", "SiteId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2L, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "Engr Tee", "TRs78", "Emo98671", true, "Seun tyu", "site456", new DateTime(2021, 11, 15, 2, 44, 38, 797, DateTimeKind.Local).AddTicks(7836), "Seun tyu" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DriverId", "EmployeeNumber", "IsActive", "Name", "SiteId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3L, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "Engr Tee", "TRs90", "Emo021", true, "John Otedola", "site460", new DateTime(2021, 11, 15, 2, 44, 38, 797, DateTimeKind.Local).AddTicks(7851), "John Otedola" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}
