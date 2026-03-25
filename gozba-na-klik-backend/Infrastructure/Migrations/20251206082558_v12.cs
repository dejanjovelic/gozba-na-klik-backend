using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2af23c86-4877-4a6e-bbe8-334a7fd14f50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2b38703-3a7b-4be7-b28e-0bfec3a49f76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7edefc0-0d12-4aa0-be68-57775bc46135");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9b193a6-de34-40e4-9a02-d364f4c14278");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0a58712-ac17-4fb7-a944-d61d413cb2b2");

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

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AssignedAt", "CourierId", "CustomerId", "DeliveredAt", "DeliveryAddressId", "DeliveryStartedAt", "OrderTime", "PickupReadyAt", "RestaurantId", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, new DateTime(2025, 12, 6, 8, 15, 58, 39, DateTimeKind.Utc).AddTicks(1129), null, 1, 0, 0.0 },
                    { 3, null, null, "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03", null, 4, null, new DateTime(2025, 12, 6, 8, 17, 58, 39, DateTimeKind.Utc).AddTicks(1144), null, 6, 0, 0.0 },
                    { 4, null, null, "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04", null, 7, null, new DateTime(2025, 12, 6, 8, 23, 58, 39, DateTimeKind.Utc).AddTicks(1145), null, 6, 0, 0.0 },
                    { 5, null, null, "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05", null, 8, null, new DateTime(2025, 12, 6, 8, 19, 58, 39, DateTimeKind.Utc).AddTicks(1147), null, 1, 0, 0.0 },
                    { 6, null, null, "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh06", null, 10, null, new DateTime(2025, 12, 6, 8, 21, 58, 39, DateTimeKind.Utc).AddTicks(1148), null, 1, 0, 0.0 },
                    { 7, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh20", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07", null, 11, null, new DateTime(2025, 12, 6, 8, 21, 58, 39, DateTimeKind.Utc).AddTicks(1150), null, 1, 1, 0.0 },
                    { 8, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh21", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh08", null, 13, null, null, null, 6, 1, 0.0 },
                    { 9, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh22", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09", null, 14, null, null, null, 6, 4, 0.0 },
                    { 10, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh23", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh10", null, 16, null, new DateTime(2025, 12, 6, 8, 25, 58, 39, DateTimeKind.Utc).AddTicks(1153), null, 7, 4, 0.0 },
                    { 11, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, new DateTime(2025, 12, 6, 8, 16, 58, 39, DateTimeKind.Utc).AddTicks(1139), null, 1, 5, 0.0 },
                    { 12, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 4, null, new DateTime(2025, 12, 6, 7, 55, 58, 39, DateTimeKind.Utc).AddTicks(1141), null, 2, 5, 0.0 },
                    { 13, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02", null, 3, null, new DateTime(2025, 12, 6, 8, 25, 58, 39, DateTimeKind.Utc).AddTicks(1142), null, 6, 5, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderMeal",
                columns: new[] { "MealId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 11, 1, 1 },
                    { 31, 1, 1 },
                    { 12, 3, 2 },
                    { 26, 3, 2 },
                    { 6, 4, 2 },
                    { 36, 4, 2 },
                    { 11, 5, 1 },
                    { 21, 5, 1 },
                    { 1, 6, 1 },
                    { 31, 6, 2 },
                    { 21, 7, 2 },
                    { 31, 7, 2 },
                    { 12, 8, 2 },
                    { 17, 8, 2 },
                    { 12, 9, 2 },
                    { 17, 9, 2 },
                    { 1, 11, 2 },
                    { 21, 11, 2 },
                    { 6, 13, 2 },
                    { 12, 13, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 31, 1 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 36, 4 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 21, 5 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 31, 6 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 21, 7 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 31, 7 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 17, 8 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 12, 9 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 17, 9 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 21, 11 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumns: new[] { "MealId", "OrderId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2af23c86-4877-4a6e-bbe8-334a7fd14f50", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "c2b38703-3a7b-4be7-b28e-0bfec3a49f76", null, "Customer", "CUSTOMER" },
                    { "c7edefc0-0d12-4aa0-be68-57775bc46135", null, "Courier", "COURIER" },
                    { "c9b193a6-de34-40e4-9a02-d364f4c14278", null, "Administrator", "ADMINISTRATOR" },
                    { "e0a58712-ac17-4fb7-a944-d61d413cb2b2", null, "Employee", "EMPLOYEE" }
                });
        }
    }
}
