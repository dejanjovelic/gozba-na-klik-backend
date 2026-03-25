using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4256d8c5-8cd2-4e48-a18b-bad01afb11e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "859957a6-efb6-4345-b9dd-ecbf4f220391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0a9ce25-efd2-44a6-9e57-544f36711ed3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa7e2e4b-6f0c-4a28-af15-8c58269dbd4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce32668d-6603-4be4-94cc-f664139bff3c");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "CreditCards",
                type: "text",
                nullable: false,
                defaultValue: "Visa");

            migrationBuilder.AddColumn<string>(
                name: "CardHolderFirstName",
                table: "CreditCards",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardHolderLastName",
                table: "CreditCards",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CardHolderFirstName", "CardHolderLastName" },
                values: new object[] { "Marko", "Markovic" });

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "CardHolderFirstName", "CardHolderLastName" },
                values: new object[] { "Mastercard", "Jelena", "Jovanovic" });

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "CardHolderFirstName", "CardHolderLastName" },
                values: new object[] { "Dina", "Petar", "Petrovic" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "CardHolderFirstName",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "CardHolderLastName",
                table: "CreditCards");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4256d8c5-8cd2-4e48-a18b-bad01afb11e0", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "859957a6-efb6-4345-b9dd-ecbf4f220391", null, "Employee", "EMPLOYEE" },
                    { "a0a9ce25-efd2-44a6-9e57-544f36711ed3", null, "Courier", "COURIER" },
                    { "aa7e2e4b-6f0c-4a28-af15-8c58269dbd4f", null, "Administrator", "ADMINISTRATOR" },
                    { "ce32668d-6603-4be4-94cc-f664139bff3c", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 32, 29, 438, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 34, 29, 438, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 40, 29, 438, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 36, 29, 438, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 38, 29, 438, DateTimeKind.Utc).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 38, 29, 438, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 42, 29, 438, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 33, 29, 438, DateTimeKind.Utc).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 12, 29, 438, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2026, 3, 16, 21, 42, 29, 438, DateTimeKind.Utc).AddTicks(6279));
        }
    }
}
