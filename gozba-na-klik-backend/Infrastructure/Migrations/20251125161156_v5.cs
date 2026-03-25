using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a00797e-f0d6-4b80-9906-8a557a63fc13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ec66f7e-017a-4ed3-b7a1-a3ea4a58eab1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0d9600-68df-4910-b9ff-de9a06483098");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a84307ee-e977-4e1b-9829-ed395f624322");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caffd48b-ce9f-42f8-9d19-9af8cd8261ce");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0958f2af-39ce-41a0-96de-347c02b4e51f", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "193461c3-f41b-42aa-9144-96bb85f80fef", null, "Administrator", "ADMINISTRATOR" },
                    { "40b15ed4-fb2d-4905-a923-e3a567a3f010", null, "Courier", "COURIER" },
                    { "43a60b11-6cf3-4f72-a0b8-8dc7062bca6c", null, "Customer", "CUSTOMER" },
                    { "b14a2d9f-5142-43e7-802f-3ff29d2fd0ac", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedAt", "OrderTime" },
                values: new object[] { null, new DateTime(2025, 11, 25, 16, 11, 55, 163, DateTimeKind.Utc).AddTicks(4083) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "AssignedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "AssignedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "AssignedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "AssignedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "AssignedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "AssignedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssignedAt", "OrderTime" },
                values: new object[] { null, new DateTime(2025, 11, 25, 16, 11, 55, 163, DateTimeKind.Utc).AddTicks(4099) });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0958f2af-39ce-41a0-96de-347c02b4e51f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "193461c3-f41b-42aa-9144-96bb85f80fef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40b15ed4-fb2d-4905-a923-e3a567a3f010");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43a60b11-6cf3-4f72-a0b8-8dc7062bca6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b14a2d9f-5142-43e7-802f-3ff29d2fd0ac");

            migrationBuilder.DropColumn(
                name: "AssignedAt",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a00797e-f0d6-4b80-9906-8a557a63fc13", null, "Courier", "COURIER" },
                    { "4ec66f7e-017a-4ed3-b7a1-a3ea4a58eab1", null, "Customer", "CUSTOMER" },
                    { "9e0d9600-68df-4910-b9ff-de9a06483098", null, "Employee", "EMPLOYEE" },
                    { "a84307ee-e977-4e1b-9829-ed395f624322", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "caffd48b-ce9f-42f8-9d19-9af8cd8261ce", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 18, 11, 45, 731, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 18, 11, 45, 731, DateTimeKind.Utc).AddTicks(1246));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "Id");
        }
    }
}
