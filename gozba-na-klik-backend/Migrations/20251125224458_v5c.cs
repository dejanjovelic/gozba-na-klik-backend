using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v5c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "OrderReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantRating = table.Column<int>(type: "integer", nullable: false),
                    RestaurantComment = table.Column<string>(type: "text", nullable: true),
                    RestaurantReviewImage = table.Column<string>(type: "text", nullable: true),
                    CourierRating = table.Column<int>(type: "integer", nullable: false),
                    CourierComment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderReview_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02ece43b-8925-4a79-98d8-9f7348576da2", null, "Courier", "COURIER" },
                    { "49f58cec-d62a-428e-886a-e8f09359a0f9", null, "Employee", "EMPLOYEE" },
                    { "ce84dc9f-1d6b-4d0f-ac95-99d4188ab11b", null, "Customer", "CUSTOMER" },
                    { "daa8e689-b331-44c5-bdff-643a45a0b6be", null, "Administrator", "ADMINISTRATOR" },
                    { "fc2a4811-54cb-476f-b287-062b815b207b", null, "RestaurantOwner", "RESTAURANTOWNER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2025, 11, 25, 22, 44, 57, 449, DateTimeKind.Utc).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 25, 22, 44, 57, 449, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_OrderId",
                table: "OrderReview",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderReview");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02ece43b-8925-4a79-98d8-9f7348576da2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49f58cec-d62a-428e-886a-e8f09359a0f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce84dc9f-1d6b-4d0f-ac95-99d4188ab11b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daa8e689-b331-44c5-bdff-643a45a0b6be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc2a4811-54cb-476f-b287-062b815b207b");

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
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2025, 11, 25, 16, 11, 55, 163, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 25, 16, 11, 55, 163, DateTimeKind.Utc).AddTicks(4099));
        }
    }
}
