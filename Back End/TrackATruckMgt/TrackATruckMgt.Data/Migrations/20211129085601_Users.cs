using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaFarge.TruckingMgt.Data.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 29, 0, 56, 0, 462, DateTimeKind.Local).AddTicks(4437) });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 29, 0, 56, 0, 462, DateTimeKind.Local).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 29, 0, 56, 0, 462, DateTimeKind.Local).AddTicks(7309) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 15, 2, 44, 38, 797, DateTimeKind.Local).AddTicks(5774) });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 15, 2, 44, 38, 797, DateTimeKind.Local).AddTicks(7836) });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 15, 2, 44, 38, 797, DateTimeKind.Local).AddTicks(7851) });
        }
    }
}
