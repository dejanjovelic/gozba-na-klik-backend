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
                name: "FK_Restaurants_RestaurantOwners_RestaurantOwnerId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Restaurants_RestaurantId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_RestaurantOwnerId",
                table: "Restaurants");

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

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "WorkingHours",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2025, 11, 28, 8, 54, 26, 266, DateTimeKind.Utc).AddTicks(3301));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 28, 8, 54, 26, 266, DateTimeKind.Utc).AddTicks(3315));

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Restaurants_RestaurantId",
                table: "WorkingHours",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Restaurants_RestaurantId",
                table: "WorkingHours");

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

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "WorkingHours",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RestaurantOwnerId",
                table: "Restaurants",
                column: "RestaurantOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantOwners_RestaurantOwnerId",
                table: "Restaurants",
                column: "RestaurantOwnerId",
                principalTable: "RestaurantOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Restaurants_RestaurantId",
                table: "WorkingHours",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
