using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackATruckMgt.Data.Migrations
{
    public partial class Again2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "True",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DriverId", "EmployeeNumber", "IsActive", "Name", "SiteId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1L, new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "Engr Tee", "TRs67", "Emo9821", true, "John Doe", "site456", new DateTime(2021, 11, 9, 6, 0, 31, 567, DateTimeKind.Local).AddTicks(3521), "John Doe" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DriverId", "EmployeeNumber", "IsActive", "Name", "SiteId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2L, new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "Engr Tee", "TRs78", "Emo98671", true, "Seun tyu", "site456", new DateTime(2021, 11, 9, 6, 0, 31, 567, DateTimeKind.Local).AddTicks(5586), "Seun tyu" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DriverId", "EmployeeNumber", "IsActive", "Name", "SiteId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3L, new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "Engr Tee", "TRs90", "Emo021", true, "John Otedola", "site460", new DateTime(2021, 11, 9, 6, 0, 31, 567, DateTimeKind.Local).AddTicks(5599), "John Otedola" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "True");
        }
    }
}
