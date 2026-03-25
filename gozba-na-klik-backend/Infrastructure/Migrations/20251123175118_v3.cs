using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
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
                keyValue: "06d0a7d8-e368-4d03-b2e3-5c7311cb7213");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3485de77-5faf-43b7-b7a2-9072370e4da4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39f14a74-4748-4068-9594-bd043a6450c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53f4f034-1bc2-459c-8711-f576165761a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b26f6d4c-4b97-435e-a9a1-25c0528a364a");

            migrationBuilder.AlterColumn<string>(
                name: "CourierId",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0daf5811-83d5-4479-ae06-13a4fc053fa2", null, "Customer", "CUSTOMER" },
                    { "24994481-bcc8-45a1-8b66-d83e5ec72630", null, "Courier", "COURIER" },
                    { "9686f93c-8897-4223-939b-76c76a56e759", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "a213de78-23de-4a5f-98e0-1702af9001d3", null, "Administrator", "ADMINISTRATOR" },
                    { "ade96f75-9a44-4be5-846f-831e9407c3b2", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 17, 51, 17, 882, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 17, 51, 17, 882, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "Id");
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
                keyValue: "0daf5811-83d5-4479-ae06-13a4fc053fa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24994481-bcc8-45a1-8b66-d83e5ec72630");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9686f93c-8897-4223-939b-76c76a56e759");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a213de78-23de-4a5f-98e0-1702af9001d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ade96f75-9a44-4be5-846f-831e9407c3b2");

            migrationBuilder.AlterColumn<string>(
                name: "CourierId",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06d0a7d8-e368-4d03-b2e3-5c7311cb7213", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "3485de77-5faf-43b7-b7a2-9072370e4da4", null, "Employee", "EMPLOYEE" },
                    { "39f14a74-4748-4068-9594-bd043a6450c8", null, "Customer", "CUSTOMER" },
                    { "53f4f034-1bc2-459c-8711-f576165761a0", null, "Courier", "COURIER" },
                    { "b26f6d4c-4b97-435e-a9a1-25c0528a364a", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 17, 31, 9, 956, DateTimeKind.Utc).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 17, 31, 9, 956, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
