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

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartingTime",
                table: "WorkingHours",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndingTime",
                table: "WorkingHours",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AddColumn<bool>(
                name: "IsRestaurantOpen",
                table: "WorkingHours",
                type: "boolean",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cb126bd-fc96-4e59-a4f5-6fc9f355023a", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "61e2c61a-2ab9-4443-a7dd-e830ec323fda", null, "Courier", "COURIER" },
                    { "c53b34ba-b1f7-4769-9f8f-8573b0f1e412", null, "Customer", "CUSTOMER" },
                    { "e9ab14a2-9a6a-4b03-88db-fb09f4ca2c2e", null, "Administrator", "ADMINISTRATOR" },
                    { "f233c406-ce05-469b-b041-4952bbf0540b", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 29, 14, 972, DateTimeKind.Utc).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 31, 14, 972, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 37, 14, 972, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 33, 14, 972, DateTimeKind.Utc).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 35, 14, 972, DateTimeKind.Utc).AddTicks(5774));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 35, 14, 972, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 39, 14, 972, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 30, 14, 972, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 9, 14, 972, DateTimeKind.Utc).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderTime",
                value: new DateTime(2026, 6, 11, 15, 39, 14, 972, DateTimeKind.Utc).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsRestaurantOpen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsRestaurantOpen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsRestaurantOpen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsRestaurantOpen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsRestaurantOpen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsRestaurantOpen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsRestaurantOpen",
                value: true);

            migrationBuilder.UpdateData(
                table: "WorkingHours",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsRestaurantOpen",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cb126bd-fc96-4e59-a4f5-6fc9f355023a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61e2c61a-2ab9-4443-a7dd-e830ec323fda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c53b34ba-b1f7-4769-9f8f-8573b0f1e412");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9ab14a2-9a6a-4b03-88db-fb09f4ca2c2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f233c406-ce05-469b-b041-4952bbf0540b");

            migrationBuilder.DropColumn(
                name: "IsRestaurantOpen",
                table: "WorkingHours");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartingTime",
                table: "WorkingHours",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndingTime",
                table: "WorkingHours",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

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
        }
    }
}
