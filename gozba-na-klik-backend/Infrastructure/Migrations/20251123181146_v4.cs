using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0daf5811-83d5-4479-ae06-13a4fc053fa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24994481-bcc8-45a1-8b66-d83e5ec72630");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9686f93c-8897-4223-939b-76c76a56e759");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a213de78-23de-4a5f-98e0-1702af9001d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ade96f75-9a44-4be5-846f-831e9407c3b2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a00797e-f0d6-4b80-9906-8a557a63fc13", null, "Courier", "COURIER" },
                    { "4ec66f7e-017a-4ed3-b7a1-a3ea4a58eab1", null, "Customer", "CUSTOMER" },
                    { "9e0d9600-68df-4910-b9ff-de9a06483098", null, "Employee", "EMPLOYEE" },
                    { "a84307ee-e977-4e1b-9829-ed395f624322", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "caffd48b-ce9f-42f8-9d19-9af8cd8261ce", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219190/Stuffed_20Peppers_20-_20NCBA_20Beef_20Aug_20202431717_zkimq0.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219263/Pizza-Capricciosa_8_raj5pt.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219415/omatsuri-2_c0esac.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219452/Barbecue-Ribs-Recipe-7_ikifom.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219475/Bol_falafels_a18c8367-1a60-4132-8e78-0f8a3f363288_p2ayhu.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219536/Gegrillte-Dorade-Rezept-ELAG-Grillplatte-Induktionskochfeld-2020-1-2_elvevn.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 7,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219553/image_vb4wvf.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219579/Authentic-Pad-Thai_square-1908_tufobi.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 9,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219644/8-quiche-500x500_uvgs6y.webp");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219669/Chicken-Tikka-Masala_0-SQ_cqaxop.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 11,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219720/frenchs_burger_styled-image_800x800_pqivq6.png");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 12,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219766/fish-soup-in-a-white-bowl-square-e1691445762883_pvfccd.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 13,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219822/Spaghetti-carbonara-1-500x500_ummyjp.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 14,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219892/vegetable_stir_fry_hn87jz.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 15,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219939/Peppercorn-Steak_ae5dkp.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 16,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219985/Vegan-Lasagna-17_sq4o7j.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 17,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761220032/close-up-of-grilled-sliced-tuna-steak-medium-rare-1_zpdonx.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 18,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761220073/cevapi-with-onion-on-oval-plater-middle-eastern-cuisine-salad-plates-and-lavash-bread_tlphkv.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 19,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761220108/Tom-Yum-soup_2_ti1rim.jpg");

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 20,
                column: "MealImageUrl",
                value: "https://res.cloudinary.com/dsgans7nh/image/upload/v1761220177/croque-monsieur-66a219aa5f0b2.jpg_h29478.jpg");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 18, 11, 45, 731, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 18, 11, 45, 731, DateTimeKind.Utc).AddTicks(1246));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a00797e-f0d6-4b80-9906-8a557a63fc13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ec66f7e-017a-4ed3-b7a1-a3ea4a58eab1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0d9600-68df-4910-b9ff-de9a06483098");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a84307ee-e977-4e1b-9829-ed395f624322");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caffd48b-ce9f-42f8-9d19-9af8cd8261ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0daf5811-83d5-4479-ae06-13a4fc053fa2", null, "Customer", "CUSTOMER" },
                    { "24994481-bcc8-45a1-8b66-d83e5ec72630", null, "Courier", "COURIER" },
                    { "9686f93c-8897-4223-939b-76c76a56e759", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "a213de78-23de-4a5f-98e0-1702af9001d3", null, "Administrator", "ADMINISTRATOR" },
                    { "ade96f75-9a44-4be5-846f-831e9407c3b2", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 7,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 9,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 11,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 12,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 13,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 14,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 15,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 16,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 17,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 18,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 19,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 20,
                column: "MealImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 17, 51, 17, 882, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderTime",
                value: new DateTime(2025, 11, 23, 17, 51, 17, 882, DateTimeKind.Utc).AddTicks(6258));
        }
    }
}
