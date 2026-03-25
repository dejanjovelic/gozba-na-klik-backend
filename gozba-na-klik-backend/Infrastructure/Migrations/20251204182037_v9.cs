using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "RestaurantRating",
                table: "OrderReviews",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "CourierRating",
                table: "OrderReviews",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19381a4a-78ba-4d22-84e9-ec170a78cee4", null, "Employee", "EMPLOYEE" },
                    { "64e452f9-d76b-485f-85b6-892c64773b21", null, "Customer", "CUSTOMER" },
                    { "65af403d-f0ed-4f52-a191-93c094ad66b7", null, "Administrator", "ADMINISTRATOR" },
                    { "8d006289-1265-405b-afba-febbf726f2cb", null, "Courier", "COURIER" },
                    { "c656c6cd-da38-40f7-8741-0ceedfc45104", null, "RestaurantOwner", "RESTAURANTOWNER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 12, 4, 18, 20, 37, 337, DateTimeKind.Utc).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2025, 12, 4, 18, 20, 37, 337, DateTimeKind.Utc).AddTicks(2833));

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_Email",
                table: "IdentityUser",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19381a4a-78ba-4d22-84e9-ec170a78cee4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e452f9-d76b-485f-85b6-892c64773b21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65af403d-f0ed-4f52-a191-93c094ad66b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d006289-1265-405b-afba-febbf726f2cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c656c6cd-da38-40f7-8741-0ceedfc45104");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantRating",
                table: "OrderReviews",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "CourierRating",
                table: "OrderReviews",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

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
    }
}
