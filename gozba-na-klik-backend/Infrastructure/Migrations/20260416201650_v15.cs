using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v15 : Migration
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

            migrationBuilder.RenameTable(
                name: "NonWorkingDate",
                newName: "NonWorkingDates");

            migrationBuilder.RenameIndex(
                name: "IX_NonWorkingDate_RestaurantId",
                table: "NonWorkingDates",
                newName: "IX_NonWorkingDates_RestaurantId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Restaurants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Restaurants",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "AverageRating",
                table: "Restaurants",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Restaurants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
                    { "0fce4865-2aba-44c6-a499-35f64e8511c4", null, "Employee", "EMPLOYEE" },
                    { "17a772e2-445d-40c1-a679-cc82726eb171", null, "Administrator", "ADMINISTRATOR" },
                    { "40d58446-aca8-4f91-9c4b-d76013a5c391", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "62353bba-0fc0-4759-9c77-e68c5860d6d4", null, "Customer", "CUSTOMER" },
                    { "95579f51-51e5-48a7-9c86-51b118cdb7a3", null, "Courier", "COURIER" }
                });

            migrationBuilder.InsertData(
                table: "NonWorkingDates",
                columns: new[] { "Id", "Date", "RestaurantId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 2, new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 3, new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 4, new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Utc), 6 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 20, 6, 50, 177, DateTimeKind.Utc).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 20, 8, 50, 177, DateTimeKind.Utc).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 20, 14, 50, 177, DateTimeKind.Utc).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 20, 10, 50, 177, DateTimeKind.Utc).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 20, 12, 50, 177, DateTimeKind.Utc).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 20, 12, 50, 177, DateTimeKind.Utc).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 20, 16, 50, 177, DateTimeKind.Utc).AddTicks(302));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 20, 7, 50, 177, DateTimeKind.Utc).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 19, 46, 50, 177, DateTimeKind.Utc).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2026, 4, 16, 20, 16, 50, 177, DateTimeKind.Utc).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsCreated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 20,
                column: "IsCreated",
                value: true);

            migrationBuilder.InsertData(
                table: "WorkingHours",
                columns: new[] { "Id", "CourierId", "DayOfTheWeek", "EndingTime", "RestaurantId", "StartingTime" },
                values: new object[,]
                {
                    { 1, null, 1, new TimeSpan(0, 16, 0, 0, 0), 5, new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, null, 2, new TimeSpan(0, 16, 0, 0, 0), 5, new TimeSpan(0, 8, 0, 0, 0) },
                    { 3, null, 3, new TimeSpan(0, 16, 0, 0, 0), 5, new TimeSpan(0, 8, 0, 0, 0) },
                    { 4, null, 4, new TimeSpan(0, 16, 0, 0, 0), 5, new TimeSpan(0, 8, 0, 0, 0) },
                    { 5, null, 1, new TimeSpan(0, 17, 0, 0, 0), 6, new TimeSpan(0, 9, 0, 0, 0) },
                    { 6, null, 2, new TimeSpan(0, 17, 0, 0, 0), 6, new TimeSpan(0, 9, 0, 0, 0) },
                    { 7, null, 3, new TimeSpan(0, 17, 0, 0, 0), 6, new TimeSpan(0, 9, 0, 0, 0) },
                    { 8, null, 4, new TimeSpan(0, 17, 0, 0, 0), 6, new TimeSpan(0, 9, 0, 0, 0) }
                });

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
                keyValue: "0fce4865-2aba-44c6-a499-35f64e8511c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17a772e2-445d-40c1-a679-cc82726eb171");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40d58446-aca8-4f91-9c4b-d76013a5c391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62353bba-0fc0-4759-9c77-e68c5860d6d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95579f51-51e5-48a7-9c86-51b118cdb7a3");

            migrationBuilder.DeleteData(
                table: "NonWorkingDates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NonWorkingDates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NonWorkingDates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NonWorkingDates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 8);

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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Restaurants",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AverageRating",
                table: "Restaurants",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonWorkingDate",
                table: "NonWorkingDate",
                column: "Id");

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
