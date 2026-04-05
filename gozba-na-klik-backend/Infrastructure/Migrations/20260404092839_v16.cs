using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonWorkingDate_Restaurants_RestaurantId",
                table: "NonWorkingDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NonWorkingDate",
                table: "NonWorkingDate");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c98d7da-c30d-49f9-b74a-b599df59f6a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b2ff1be-1bed-42c4-bad3-18d6c6ba7a48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2ba20cb-9525-4ca8-aec2-d4c72a290b8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecb04a14-5931-4bb9-88a4-d31b822f23ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edeaa4dc-6478-429d-8258-97c42a536f4b");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "WorkingHours");

            migrationBuilder.RenameTable(
                name: "NonWorkingDate",
                newName: "NonWorkingDates");

            migrationBuilder.RenameIndex(
                name: "IX_NonWorkingDate_RestaurantId",
                table: "NonWorkingDates",
                newName: "IX_NonWorkingDates_RestaurantId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCreated",
                table: "Restaurants",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonWorkingDates",
                table: "NonWorkingDates",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03ea99c6-dcbb-4772-a774-e85d924583d0", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "3cf8192b-8e22-4225-a737-edf64a269a42", null, "Employee", "EMPLOYEE" },
                    { "5d0b75e0-6e0c-4677-8fd8-17cf693f066b", null, "Customer", "CUSTOMER" },
                    { "aa55fc6e-0b65-40f0-a08c-f1a45d0aa6d5", null, "Courier", "COURIER" },
                    { "cb706a3b-7229-4871-89b8-749f51f99028", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 9, 18, 39, 248, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 9, 20, 39, 248, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 9, 26, 39, 248, DateTimeKind.Utc).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 9, 22, 39, 248, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 9, 24, 39, 248, DateTimeKind.Utc).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 9, 24, 39, 248, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 9, 28, 39, 248, DateTimeKind.Utc).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 9, 19, 39, 248, DateTimeKind.Utc).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 8, 58, 39, 248, DateTimeKind.Utc).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2026, 4, 4, 9, 28, 39, 248, DateTimeKind.Utc).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsCreated",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 20,
                column: "IsCreated",
                value: false);

            migrationBuilder.AddForeignKey(
                name: "FK_NonWorkingDates_Restaurants_RestaurantId",
                table: "NonWorkingDates",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonWorkingDates_Restaurants_RestaurantId",
                table: "NonWorkingDates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NonWorkingDates",
                table: "NonWorkingDates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03ea99c6-dcbb-4772-a774-e85d924583d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cf8192b-8e22-4225-a737-edf64a269a42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d0b75e0-6e0c-4677-8fd8-17cf693f066b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa55fc6e-0b65-40f0-a08c-f1a45d0aa6d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb706a3b-7229-4871-89b8-749f51f99028");

            migrationBuilder.DropColumn(
                name: "IsCreated",
                table: "Restaurants");

            migrationBuilder.RenameTable(
                name: "NonWorkingDates",
                newName: "NonWorkingDate");

            migrationBuilder.RenameIndex(
                name: "IX_NonWorkingDates_RestaurantId",
                table: "NonWorkingDate",
                newName: "IX_NonWorkingDate_RestaurantId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkingHours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "WorkingHours",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonWorkingDate",
                table: "NonWorkingDate",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c98d7da-c30d-49f9-b74a-b599df59f6a2", null, "Administrator", "ADMINISTRATOR" },
                    { "8b2ff1be-1bed-42c4-bad3-18d6c6ba7a48", null, "Customer", "CUSTOMER" },
                    { "b2ba20cb-9525-4ca8-aec2-d4c72a290b8e", null, "Courier", "COURIER" },
                    { "ecb04a14-5931-4bb9-88a4-d31b822f23ed", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "edeaa4dc-6478-429d-8258-97c42a536f4b", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 39, 20, 538, DateTimeKind.Utc).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 41, 20, 538, DateTimeKind.Utc).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 47, 20, 538, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 43, 20, 538, DateTimeKind.Utc).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 45, 20, 538, DateTimeKind.Utc).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 45, 20, 538, DateTimeKind.Utc).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 49, 20, 538, DateTimeKind.Utc).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 40, 20, 538, DateTimeKind.Utc).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 19, 20, 538, DateTimeKind.Utc).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2026, 4, 2, 20, 49, 20, 538, DateTimeKind.Utc).AddTicks(502));

            migrationBuilder.AddForeignKey(
                name: "FK_NonWorkingDate_Restaurants_RestaurantId",
                table: "NonWorkingDate",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
