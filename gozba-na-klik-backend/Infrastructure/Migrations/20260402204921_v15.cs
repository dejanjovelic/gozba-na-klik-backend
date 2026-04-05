using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ff54d8-ee0f-41bb-aac6-0ec9151e70d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b08bc92-22e5-48e2-81d0-4d00f450045e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9561484c-ef17-4be5-b0ff-60bfed48201a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9580ebbe-9c10-4107-9d8e-9c22b4aa9619");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fcfec60-8852-4019-81b1-ea24b6cfad06");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkingHours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "WorkingHours",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c98d7da-c30d-49f9-b74a-b599df59f6a2", null, "Administrator", "ADMINISTRATOR" },
                    { "8b2ff1be-1bed-42c4-bad3-18d6c6ba7a48", null, "Customer", "CUSTOMER" },
                    { "b2ba20cb-9525-4ca8-aec2-d4c72a290b8e", null, "Courier", "COURIER" },
                    { "ecb04a14-5931-4bb9-88a4-d31b822f23ed", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "edeaa4dc-6478-429d-8258-97c42a536f4b", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 39, 20, 538, DateTimeKind.Utc).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 41, 20, 538, DateTimeKind.Utc).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 47, 20, 538, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 43, 20, 538, DateTimeKind.Utc).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 45, 20, 538, DateTimeKind.Utc).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 45, 20, 538, DateTimeKind.Utc).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 49, 20, 538, DateTimeKind.Utc).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 40, 20, 538, DateTimeKind.Utc).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 19, 20, 538, DateTimeKind.Utc).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 49, 20, 538, DateTimeKind.Utc).AddTicks(502));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c98d7da-c30d-49f9-b74a-b599df59f6a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b2ff1be-1bed-42c4-bad3-18d6c6ba7a48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2ba20cb-9525-4ca8-aec2-d4c72a290b8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecb04a14-5931-4bb9-88a4-d31b822f23ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edeaa4dc-6478-429d-8258-97c42a536f4b");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "WorkingHours");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35ff54d8-ee0f-41bb-aac6-0ec9151e70d9", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "6b08bc92-22e5-48e2-81d0-4d00f450045e", null, "Employee", "EMPLOYEE" },
                    { "9561484c-ef17-4be5-b0ff-60bfed48201a", null, "Customer", "CUSTOMER" },
                    { "9580ebbe-9c10-4107-9d8e-9c22b4aa9619", null, "Administrator", "ADMINISTRATOR" },
                    { "9fcfec60-8852-4019-81b1-ea24b6cfad06", null, "Courier", "COURIER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 36, 21, 572, DateTimeKind.Utc).AddTicks(418));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 38, 21, 572, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 44, 21, 572, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 40, 21, 572, DateTimeKind.Utc).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 42, 21, 572, DateTimeKind.Utc).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 42, 21, 572, DateTimeKind.Utc).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 46, 21, 572, DateTimeKind.Utc).AddTicks(447));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 37, 21, 572, DateTimeKind.Utc).AddTicks(430));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 16, 21, 572, DateTimeKind.Utc).AddTicks(432));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2026, 3, 25, 15, 46, 21, 572, DateTimeKind.Utc).AddTicks(434));
        }
    }
}
