using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderReview_Orders_OrderId",
                table: "OrderReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderReview",
                table: "OrderReview");

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

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "OrderReview",
                newName: "OrderReviews");

            migrationBuilder.RenameIndex(
                name: "IX_OrderReview_OrderId",
                table: "OrderReviews",
                newName: "IX_OrderReviews_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderReviews",
                table: "OrderReviews",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1af19ce0-b29d-4de5-9572-27ab3c6460c5", null, "Employee", "EMPLOYEE" },
                    { "4e5ab966-9158-4d80-afd1-1a434acc2ad9", null, "Courier", "COURIER" },
                    { "75cf0aa5-b689-43fb-9a52-bc7217547fcc", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "cda7a015-831a-40a2-9212-b7836525f10a", null, "Customer", "CUSTOMER" },
                    { "d5d475c8-9674-4eba-b8d5-ad3d438fdfba", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 27, 1, 22, 21, 99, DateTimeKind.Utc).AddTicks(6626));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AssignedAt", "CourierId", "CustomerId", "DeliveredAt", "DeliveryAddressId", "DeliveryStartedAt", "OrderTime", "RestaurantId", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 11, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, null, 20, 5, 0.0 },
                    { 12, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, null, 20, 5, 0.0 },
                    { 13, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02", null, 3, null, new DateTime(2025, 11, 27, 1, 22, 21, 99, DateTimeKind.Utc).AddTicks(6611), 19, 5, 0.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderReviews_Orders_OrderId",
                table: "OrderReviews",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderReviews_Orders_OrderId",
                table: "OrderReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderReviews",
                table: "OrderReviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1af19ce0-b29d-4de5-9572-27ab3c6460c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e5ab966-9158-4d80-afd1-1a434acc2ad9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75cf0aa5-b689-43fb-9a52-bc7217547fcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cda7a015-831a-40a2-9212-b7836525f10a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5d475c8-9674-4eba-b8d5-ad3d438fdfba");

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

            migrationBuilder.RenameTable(
                name: "OrderReviews",
                newName: "OrderReview");

            migrationBuilder.RenameIndex(
                name: "IX_OrderReviews_OrderId",
                table: "OrderReview",
                newName: "IX_OrderReview_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderReview",
                table: "OrderReview",
                column: "Id");

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
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 25, 22, 44, 57, 449, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AssignedAt", "CourierId", "CustomerId", "DeliveredAt", "DeliveryAddressId", "DeliveryStartedAt", "OrderTime", "RestaurantId", "Status", "TotalPrice" },
                values: new object[] { 2, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02", null, 3, null, new DateTime(2025, 11, 25, 22, 44, 57, 449, DateTimeKind.Utc).AddTicks(3679), 19, 2, 0.0 });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderReview_Orders_OrderId",
                table: "OrderReview",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
