using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05207f3c-7302-4474-84fc-e63a6adcbedf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "195410d9-4a93-4514-97bf-6257c9503c7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f0e5c67-8e18-41fa-8aa8-b5e034f8d842");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6bb435-f087-4328-84d8-62026d59949d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99349df0-327c-49f5-974f-26af1d5227f5");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedAt",
                table: "OrderReviews",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1249c794-cd90-4665-9ef9-112629565277", null, "Courier", "COURIER" },
                    { "12d416a7-2454-4300-902e-04230044e1e0", null, "Customer", "CUSTOMER" },
                    { "4cee265e-a4a1-404c-9f94-1820c76066b4", null, "Employee", "EMPLOYEE" },
                    { "7821bd2e-0953-4a14-992f-b9ccb320b3bf", null, "Administrator", "ADMINISTRATOR" },
                    { "e2fadd44-710b-433d-8d71-7f3ce21ac845", null, "RestaurantOwner", "RESTAURANTOWNER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 28, 23, 28, 51, 419, DateTimeKind.Utc).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2025, 11, 28, 23, 28, 51, 419, DateTimeKind.Utc).AddTicks(6375));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1249c794-cd90-4665-9ef9-112629565277");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12d416a7-2454-4300-902e-04230044e1e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cee265e-a4a1-404c-9f94-1820c76066b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7821bd2e-0953-4a14-992f-b9ccb320b3bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2fadd44-710b-433d-8d71-7f3ce21ac845");

            migrationBuilder.DropColumn(
                name: "PostedAt",
                table: "OrderReviews");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05207f3c-7302-4474-84fc-e63a6adcbedf", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "195410d9-4a93-4514-97bf-6257c9503c7f", null, "Employee", "EMPLOYEE" },
                    { "6f0e5c67-8e18-41fa-8aa8-b5e034f8d842", null, "Courier", "COURIER" },
                    { "7b6bb435-f087-4328-84d8-62026d59949d", null, "Administrator", "ADMINISTRATOR" },
                    { "99349df0-327c-49f5-974f-26af1d5227f5", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 28, 21, 8, 34, 723, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2025, 11, 28, 21, 8, 34, 723, DateTimeKind.Utc).AddTicks(6230));
        }
    }
}
