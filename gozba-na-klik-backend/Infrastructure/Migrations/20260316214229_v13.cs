using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16827ced-cd64-4461-975f-488efb5078f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38fb245e-ac55-43df-a8e7-ba1733528230");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62769625-4466-4e1e-97c6-09a4db4f1d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3993cd9-86e1-481d-a632-aa8c63c85916");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df1329c9-f6a9-41e9-b0f3-e0e9a1737c7b");

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bank = table.Column<string>(type: "text", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_Customers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "Id", "Bank", "CardNumber", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Banca Intesa", "1234 5678 1478 5296", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01" },
                    { 2, "OTP Banka", "1234 5678 1478 5297", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01" },
                    { 3, "MOBI Banka", "1234 5678 1478 5298", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02" }
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

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_OwnerId",
                table: "CreditCards",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16827ced-cd64-4461-975f-488efb5078f2", null, "Employee", "EMPLOYEE" },
                    { "38fb245e-ac55-43df-a8e7-ba1733528230", null, "Courier", "COURIER" },
                    { "62769625-4466-4e1e-97c6-09a4db4f1d91", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "d3993cd9-86e1-481d-a632-aa8c63c85916", null, "Customer", "CUSTOMER" },
                    { "df1329c9-f6a9-41e9-b0f3-e0e9a1737c7b", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 8, 15, 58, 39, DateTimeKind.Utc).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 8, 17, 58, 39, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 8, 23, 58, 39, DateTimeKind.Utc).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 8, 19, 58, 39, DateTimeKind.Utc).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 8, 21, 58, 39, DateTimeKind.Utc).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 8, 21, 58, 39, DateTimeKind.Utc).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 8, 25, 58, 39, DateTimeKind.Utc).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 8, 16, 58, 39, DateTimeKind.Utc).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 7, 55, 58, 39, DateTimeKind.Utc).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2025, 12, 6, 8, 25, 58, 39, DateTimeKind.Utc).AddTicks(1142));
        }
    }
}
