using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03a8f4d6-b345-4ff9-887a-4e9983c346f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49bc827c-2976-4eec-9a51-eaf8d8c95785");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "616cd9fe-9969-4e80-86c5-76816f055367");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7540f080-98a9-4ff1-a1ee-c05c5c4c655f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77f32c2c-f6f7-4f5b-b170-d47c3ec25b80");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "OrderReviews",
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
                    table.PrimaryKey("PK_OrderReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderReviews_Orders_OrderId",
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

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AssignedAt", "CourierId", "CustomerId", "DeliveredAt", "DeliveryAddressId", "DeliveryStartedAt", "OrderTime", "RestaurantId", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 11, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, null, 20, 5, 0.0 },
                    { 12, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, null, 20, 5, 0.0 },
                    { 13, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02", null, 3, null, new DateTime(2025, 11, 28, 21, 8, 34, 723, DateTimeKind.Utc).AddTicks(6230), 19, 5, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderReviews_OrderId",
                table: "OrderReviews",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderReviews");

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

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03a8f4d6-b345-4ff9-887a-4e9983c346f0", null, "Administrator", "ADMINISTRATOR" },
                    { "49bc827c-2976-4eec-9a51-eaf8d8c95785", null, "Customer", "CUSTOMER" },
                    { "616cd9fe-9969-4e80-86c5-76816f055367", null, "Employee", "EMPLOYEE" },
                    { "7540f080-98a9-4ff1-a1ee-c05c5c4c655f", null, "Courier", "COURIER" },
                    { "77f32c2c-f6f7-4f5b-b170-d47c3ec25b80", null, "RestaurantOwner", "RESTAURANTOWNER" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 28, 8, 54, 26, 266, DateTimeKind.Utc).AddTicks(3315));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AssignedAt", "CourierId", "CustomerId", "DeliveredAt", "DeliveryAddressId", "DeliveryStartedAt", "OrderTime", "RestaurantId", "Status", "TotalPrice" },
                values: new object[] { 2, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02", null, 3, null, new DateTime(2025, 11, 28, 8, 54, 26, 266, DateTimeKind.Utc).AddTicks(3301), 19, 2, 0.0 });
        }
    }
}
