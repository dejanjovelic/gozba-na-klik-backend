using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "PickupReadyAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44aebe7f-e18e-4ce6-8fea-c9bf385f32e7", null, "Customer", "CUSTOMER" },
                    { "60ba8ba9-1810-4c89-ac35-b6109228b099", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "9f9f18ef-e244-4f82-b8ec-65148e03fb47", null, "Employee", "EMPLOYEE" },
                    { "c089c48e-7d11-402e-8785-bb856b9ff2e1", null, "Courier", "COURIER" },
                    { "e6780d29-9d11-432d-a539-6b3afa2ebd00", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OrderTime", "PickupReadyAt" },
                values: new object[] { new DateTime(2025, 12, 5, 0, 58, 38, 979, DateTimeKind.Utc).AddTicks(9323), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                column: "PickupReadyAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "OrderTime", "PickupReadyAt" },
                values: new object[] { new DateTime(2025, 12, 5, 0, 58, 38, 979, DateTimeKind.Utc).AddTicks(9291), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44aebe7f-e18e-4ce6-8fea-c9bf385f32e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60ba8ba9-1810-4c89-ac35-b6109228b099");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f9f18ef-e244-4f82-b8ec-65148e03fb47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c089c48e-7d11-402e-8785-bb856b9ff2e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6780d29-9d11-432d-a539-6b3afa2ebd00");

            migrationBuilder.DropColumn(
                name: "PickupReadyAt",
                table: "Orders");

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
        }
    }
}
