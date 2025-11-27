using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v6c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1af19ce0-b29d-4de5-9572-27ab3c6460c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e5ab966-9158-4d80-afd1-1a434acc2ad9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75cf0aa5-b689-43fb-9a52-bc7217547fcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cda7a015-831a-40a2-9212-b7836525f10a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5d475c8-9674-4eba-b8d5-ad3d438fdfba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cabcac1-4f31-4104-9e57-bcbcf763bfc3", null, "Customer", "CUSTOMER" },
                    { "342e1832-a9a3-426c-b2bd-c925b855587c", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "3bd044b0-1ed9-444b-b548-8824cd418e2e", null, "Administrator", "ADMINISTRATOR" },
                    { "49250648-f6cb-4655-abf7-0597af4d3c7d", null, "Employee", "EMPLOYEE" },
                    { "73a3cf71-d9f4-4a28-a173-dae559ab6a64", null, "Courier", "COURIER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 27, 17, 27, 26, 493, DateTimeKind.Utc).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2025, 11, 27, 17, 27, 26, 493, DateTimeKind.Utc).AddTicks(2160));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cabcac1-4f31-4104-9e57-bcbcf763bfc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "342e1832-a9a3-426c-b2bd-c925b855587c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd044b0-1ed9-444b-b548-8824cd418e2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49250648-f6cb-4655-abf7-0597af4d3c7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73a3cf71-d9f4-4a28-a173-dae559ab6a64");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1af19ce0-b29d-4de5-9572-27ab3c6460c5", null, "Employee", "EMPLOYEE" },
                    { "4e5ab966-9158-4d80-afd1-1a434acc2ad9", null, "Courier", "COURIER" },
                    { "75cf0aa5-b689-43fb-9a52-bc7217547fcc", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "cda7a015-831a-40a2-9212-b7836525f10a", null, "Customer", "CUSTOMER" },
                    { "d5d475c8-9674-4eba-b8d5-ad3d438fdfba", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 27, 1, 22, 21, 99, DateTimeKind.Utc).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2025, 11, 27, 1, 22, 21, 99, DateTimeKind.Utc).AddTicks(6611));
        }
    }
}
