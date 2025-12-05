using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44aebe7f-e18e-4ce6-8fea-c9bf385f32e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60ba8ba9-1810-4c89-ac35-b6109228b099");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f9f18ef-e244-4f82-b8ec-65148e03fb47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c089c48e-7d11-402e-8785-bb856b9ff2e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6780d29-9d11-432d-a539-6b3afa2ebd00");

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
                keyValue: 10);

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
                table: "Allergens",
                columns: new[] { "Id", "Name" },
                values: new object[] { 28, "sesame" });

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

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Description", "MealImageUrl", "MealName", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 21, "Traditional beef stew with paprika.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954120/images_illzvj.webp", "Goulash", 7.5, 1 },
                    { 22, "Classic pizza with tomato, mozzarella, and basil.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954281/Margherita-Pizza-093_k22mse.jpg", "Margherita Pizza", 7.0, 2 },
                    { 23, "Sushi roll with eel, avocado, and cucumber.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954346/Dragon-Roll-0293-II_pj3c3r.jpg", "Dragon Roll", 11.5, 3 },
                    { 24, "Slow-cooked pork with BBQ sauce in a bun.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954479/Pulled-Pork-Sandwich-Recipe-ChelseasMessyApron-1200-1_namwcs.jpg", "Pulled Pork Sandwich", 9.0, 4 },
                    { 25, "Creamy hummus served with pita bread.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954541/hummus-trio-I-howsweeteats.com-10_fmrefd.jpg", "Hummus Plate", 6.0, 5 },
                    { 26, "Creamy risotto with shrimp and parmesan.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954582/shrimp-risotto-22-scaled_xoli9f.jpg", "Shrimp Risotto", 12.0, 6 },
                    { 27, "Traditional Balkan pastry filled with cheese.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954664/turkish-tray-borek-cheese-peynirli-tepsi-borek-6.jpg_uezh8i.webp", "Burek with Cheese", 5.0, 7 },
                    { 28, "Thai curry with coconut milk and vegetables.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954686/IMG_4915_qjfrtt.jpg", "Green Curry", 9.5, 8 },
                    { 29, "French vegetable stew with zucchini and eggplant.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954748/images_euol1a.webp", "Ratatouille", 7.5, 9 },
                    { 30, "Indian chicken curry with butter and cream.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954797/butter-chicken-recipe-5_jiowpv.jpg", "Butter Chicken", 10.0, 10 },
                    { 31, "Serbian grilled meat patty with spices.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954834/images_bmioxo.webp", "Pljeskavica", 7.0, 1 },
                    { 32, "Pizza topped with prosciutto and arugula.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954880/Prosciutto_and_Hot_Honey_Pizza_2400x1000-1700x708.1742499513_vioq1c.jpg", "Prosciutto Pizza", 9.0, 2 },
                    { 33, "Crispy fried shrimp in tempura batter.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954927/shrimp-tempura-A_l9rfcm.jpg", "Tempura Shrimp", 10.5, 3 },
                    { 34, "Spicy chicken wings with blue cheese dip.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764954986/IMG_0509-scaled_npygwo.jpg", "Buffalo Wings", 8.0, 4 },
                    { 35, "Fresh salad with bulgur, parsley, and lemon.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764955020/Grain-Free-Tabbouleh-Salad-11-500x500_w2ifr0.jpg", "Tabbouleh Salad", 6.5, 5 },
                    { 36, "Fried calamari served with tartar sauce.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764955065/fried-calamari-recipe-7-250x250_ypxk6a.jpg", "Calamari Rings", 9.0, 6 },
                    { 37, "Cabbage rolls stuffed with minced meat.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764955112/sarma_knkbrc.jpg", "Sarma", 6.0, 7 },
                    { 38, "Thai curry with peanuts and potatoes.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764955164/massaman-curry-recipe-9_ojxwjg.jpg", "Massaman Curry", 9.5, 8 },
                    { 39, "French dessert with chocolate or vanilla.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764955206/images_qgzazn.webp", "Soufflé", 6.5, 9 },
                    { 40, "Indian curry with paneer cheese cubes.", "https://res.cloudinary.com/dsgans7nh/image/upload/v1764955297/butter_paneer_curry_98394_16x9_n044l0.jpg", "Paneer Curry", 9.0, 10 }
                });

            migrationBuilder.InsertData(
                table: "MealAllergens",
                columns: new[] { "AllergenId", "MealId" },
                values: new object[,]
                {
                    { 1, 21 },
                    { 1, 22 },
                    { 1, 23 },
                    { 1, 24 },
                    { 1, 27 },
                    { 1, 31 },
                    { 1, 32 },
                    { 1, 33 },
                    { 1, 35 },
                    { 1, 36 },
                    { 1, 37 },
                    { 5, 26 },
                    { 5, 33 },
                    { 8, 33 },
                    { 8, 39 },
                    { 9, 23 },
                    { 10, 22 },
                    { 10, 26 },
                    { 10, 27 },
                    { 10, 28 },
                    { 10, 30 },
                    { 10, 32 },
                    { 10, 34 },
                    { 10, 38 },
                    { 10, 39 },
                    { 10, 40 },
                    { 11, 28 },
                    { 11, 38 },
                    { 12, 23 },
                    { 16, 28 },
                    { 16, 38 },
                    { 22, 21 },
                    { 22, 29 },
                    { 22, 35 },
                    { 22, 37 },
                    { 23, 24 },
                    { 24, 25 },
                    { 27, 36 },
                    { 28, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 22 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 24 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 27 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 31 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 32 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 33 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 35 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 36 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 37 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 5, 26 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 5, 33 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 8, 33 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 8, 39 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 9, 23 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 22 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 26 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 27 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 28 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 30 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 32 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 34 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 38 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 39 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 40 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 11, 28 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 11, 38 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 12, 23 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 16, 28 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 16, 38 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 22, 21 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 22, 29 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 22, 35 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 22, 37 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 23, 24 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 24, 25 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 27, 36 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 28, 25 });

            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44aebe7f-e18e-4ce6-8fea-c9bf385f32e7", null, "Customer", "CUSTOMER" },
                    { "60ba8ba9-1810-4c89-ac35-b6109228b099", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "9f9f18ef-e244-4f82-b8ec-65148e03fb47", null, "Employee", "EMPLOYEE" },
                    { "c089c48e-7d11-402e-8785-bb856b9ff2e1", null, "Courier", "COURIER" },
                    { "e6780d29-9d11-432d-a539-6b3afa2ebd00", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AssignedAt", "CourierId", "CustomerId", "DeliveredAt", "DeliveryAddressId", "DeliveryStartedAt", "OrderTime", "PickupReadyAt", "RestaurantId", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, null, null, 20, 0, 0.0 },
                    { 3, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh16", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03", null, 4, null, null, null, 19, 0, 0.0 },
                    { 4, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh17", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04", null, 7, null, null, null, 18, 0, 0.0 },
                    { 5, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh18", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05", null, 8, null, null, null, 18, 0, 0.0 },
                    { 6, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh19", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh06", null, 10, null, null, null, 18, 0, 0.0 },
                    { 7, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh20", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07", null, 11, null, null, null, 19, 1, 0.0 },
                    { 8, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh21", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh08", null, 13, null, null, null, 20, 1, 0.0 },
                    { 9, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh22", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09", null, 14, null, null, null, 20, 4, 0.0 },
                    { 10, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh23", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh10", null, 16, null, new DateTime(2025, 12, 5, 0, 58, 38, 979, DateTimeKind.Utc).AddTicks(9323), null, 20, 4, 0.0 },
                    { 11, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, null, null, 20, 5, 0.0 },
                    { 12, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, null, null, 20, 5, 0.0 },
                    { 13, null, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02", null, 3, null, new DateTime(2025, 12, 5, 0, 58, 38, 979, DateTimeKind.Utc).AddTicks(9291), null, 19, 5, 0.0 }
                });
        }
    }
}
