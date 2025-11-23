using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gozba_na_klik_backend.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27074fea-1afb-45ac-ad63-9145c8f9932a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b45c538-e69c-4a0a-a516-e1df644ecc0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7a2ffb0-3313-4338-8cec-46c78d71063b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda195a7-1532-4a80-a12a-c198dc4f38b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2ce29bd-22cf-4558-94bb-b618e9a6902c");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CustomerId", "Street", "StreetNumber", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Belgrade", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", "Main Street", 12, "11000" },
                    { 2, "Novi Sad", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", "Green Avenue", 3, "21000" },
                    { 3, "Niš", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02", "Sunset Blvd", 44, "18000" },
                    { 4, "Belgrade", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03", "Kralja Petra", 8, "11000" },
                    { 5, "Belgrade", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03", "Vojvode Stepe", 126, "11010" },
                    { 6, "Zemun", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03", "Cara Dušana", 22, "11080" },
                    { 7, "Belgrade", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04", "Ruzveltova", 33, "11120" },
                    { 8, "Novi Sad", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05", "Bulevar Oslobođenja", 99, "21000" },
                    { 9, "Novi Sad", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05", "Zmaj Jovina", 11, "21000" },
                    { 10, "Belgrade", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh06", "Nemanjina", 5, "11000" },
                    { 11, "Subotica", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07", "Gogoljeva", 15, "24000" },
                    { 12, "Subotica", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07", "Matije Gupca", 2, "24000" },
                    { 13, "Kragujevac", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh08", "Partizanska", 66, "34000" },
                    { 14, "Čačak", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09", "Vladimira Nazora", 7, "32000" },
                    { 15, "Čačak", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09", "Trg Oslobođenja", 1, "32000" },
                    { 16, "Pančevo", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh10", "Industrijska", 10, "26000" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06d0a7d8-e368-4d03-b2e3-5c7311cb7213", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "3485de77-5faf-43b7-b7a2-9072370e4da4", null, "Employee", "EMPLOYEE" },
                    { "39f14a74-4748-4068-9594-bd043a6450c8", null, "Customer", "CUSTOMER" },
                    { "53f4f034-1bc2-459c-8711-f576165761a0", null, "Courier", "COURIER" },
                    { "b26f6d4c-4b97-435e-a9a1-25c0528a364a", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "AverageRating", "Capacity", "City", "Description", "Name", "RestaurantImageUrl", "RestaurantOwnerId" },
                values: new object[,]
                {
                    { 1, "Kralja Petra 12", 6.5, 60, "Belgrade", "Modern Serbian cuisine with a twist.", "Bistro Nova", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760980868/1701656104-Le-Petiti-Bistro-Blue-Centar-13_adciqg.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24" },
                    { 2, "Cara Dušana 45", 9.5, 80, "Novi Sad", "Authentic Italian trattoria.", "La Tavola", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981334/caption_e52wiq.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24" },
                    { 3, "Bulevar Oslobođenja 88", 8.1999999999999993, 40, "Niš", "Japanese sushi bar with minimalist ambiance.", "Sakura Zen", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981371/348s_o6zhl9.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24" },
                    { 4, "Trg Slobode 3", 3.7999999999999998, 100, "Subotica", "American-style BBQ with craft beers.", "Grill & Chill", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981740/348s_jvrtl3.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24" },
                    { 5, "Njegoševa 21", 5.0, 50, "Belgrade", "Vegan restaurant with organic dishes.", "Green Wave", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981837/AC9h4noKhAJV-_f5ucmgN7g1uu9vls7RQwFmyblYG2NoZPvK95_Go_jejqToiFswNCJ4-_fS2fTYgpCI5WdS_gfmLhjPLdx3iAPbXUCdeikQHC9o-ZPvLnI8UwM-jWS6mxXZ_bgEMXao_s680-w680-h510-rw_jdbfsp.webp", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh25" },
                    { 6, "Obala 7", 5.0, 90, "Herceg Novi", "Mediterranean cuisine with a sea view.", "Casa del Mar", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981920/LaDama_10881_20_1_ojaujg.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh25" },
                    { 7, "Vojvode Mišića 14", 5.0, 70, "Kragujevac", "Traditional homemade Serbian food.", "Grandma's Kitchen", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981760/im-65599456_e7zznz.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh26" },
                    { 8, "Zmaj Jovina 9", 5.0, 85, "Novi Sad", "Fusion cuisine in a modern setting.", "Urban Spoon", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760982086/5dc498fe695b58645d6f1dbc_jexb15.png", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh27" },
                    { 9, "Francuska 5", 8.0, 45, "Belgrade", "French bistro with croissants and wine.", "Le Petit Café", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981871/images_yybf2j.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh27" },
                    { 10, "Đure Jakšića 33", 9.0, 60, "Zrenjanin", "Indian cuisine with authentic spices.", "Tandoori Flame", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985797/a-chef-is-cooking-in-his-restaurants-kitchen_gfpjj0.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh28" },
                    { 11, "Miletićeva 18", 7.0, 55, "Pančevo", "Gourmet burgers with homemade sauces.", "Burger Lab", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985725/premium_photo-1661883237884-263e8de8869b_fhmc5u.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh29" },
                    { 12, "Dunavska 2", 5.0, 75, "Sombor", "Seafood specialties and river fish.", "Fish Pot", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981672/348s_gedljh.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh30" },
                    { 13, "Kneza Miloša 27", 5.4000000000000004, 65, "Belgrade", "Fresh pasta and Italian desserts.", "Pasta Mia", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985883/348s_fheyvs.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh31" },
                    { 14, "Nikole Pašića 10", 6.7000000000000002, 80, "Niš", "Asian cuisine with wok and curry dishes.", "Orient Express", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985977/348s_pumoab.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh32" },
                    { 15, "Bulevar Evrope 21", 8.5999999999999996, 95, "Novi Sad", "Premium steaks and fine wines.", "Steakhouse 21", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760986014/ejhsj8xcmjuwdsi8qdmj.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh33" },
                    { 16, "Gundulićeva 6", 5.0, 70, "Belgrade", "Rustic ambiance with local specialties.", "Nest", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985649/Most_Beautiful_Restaurants_scotland_December23_PR_Global_pafswr.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh32" },
                    { 17, "Petrovaradinska 4", 5.0, 60, "Novi Sad", "Spanish tapas and sangria.", "Tapas Bar", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760970771/slikaRestorana1_hibuiy.png", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh28" },
                    { 18, "Glavna 1", 5.0, 100, "Valjevo", "Authentic tavern with live folk music.", "Marko's Tavern", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985542/07best-restaurants-nashville15-jbkq-videoSixteenByNineJumbo1600_ns15cb.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh28" },
                    { 19, "Vojvode Stepe 19", 5.0, 50, "Belgrade", "Thai cuisine with exotic flavors.", "Thai Orchid", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760986076/ix3atyp8yzjh6a25r2ms.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh29" },
                    { 20, "Skandinavska 3", 5.0, 40, "Novi Sad", "Nordic cuisine with minimalist design.", "Nordic Table", "https://res.cloudinary.com/dsgans7nh/image/upload/v1760986113/Hakkaiza-industrial-restaurant-design2_vyopcv.jpg", "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh30" }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Description", "MealImageUrl", "MealName", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Homemade peppers stuffed with minced meat and rice.", null, "Stuffed Peppers", 6.5, 1 },
                    { 2, "Classic pizza with ham, mushrooms, and cheese.", null, "Capricciosa Pizza", 8.0, 2 },
                    { 3, "Assorted nigiri, maki, and sashimi rolls.", null, "Sushi Mix", 12.5, 3 },
                    { 4, "Smoked pork ribs with homemade BBQ sauce.", null, "BBQ Ribs", 14.0, 4 },
                    { 5, "Vegan bowl with falafel, hummus, and fresh veggies.", null, "Falafel Bowl", 7.5, 5 },
                    { 6, "Fresh sea bream with lemon and herbs.", null, "Grilled Sea Bream", 13.0, 6 },
                    { 7, "Traditional Serbian rolls with meat and rice.", null, "Cabbage Rolls", 6.0, 7 },
                    { 8, "Thai noodles with peanuts, eggs, and vegetables.", null, "Pad Thai", 9.5, 8 },
                    { 9, "French tart with eggs, cheese, and bacon.", null, "Quiche Lorraine", 7.0, 9 },
                    { 10, "Chicken in creamy Indian tomato sauce.", null, "Chicken Tikka Masala", 10.5, 10 },
                    { 11, "Beef burger with cheese, lettuce, and sauce.", null, "Classic Burger", 8.5, 1 },
                    { 12, "Traditional soup made from river fish.", null, "Fish Soup", 5.5, 6 },
                    { 13, "Pasta with pancetta, eggs, and parmesan.", null, "Pasta Carbonara", 9.0, 2 },
                    { 14, "Mixed vegetables stir-fried in soy sauce.", null, "Wok Veggies", 7.0, 8 },
                    { 15, "Premium beef steak with creamy pepper sauce.", null, "Peppercorn Steak", 15.5, 4 },
                    { 16, "Lasagna with zucchini, eggplant, and tofu.", null, "Vegan Lasagna", 8.0, 5 },
                    { 17, "Grilled tuna fillet with lime and arugula.", null, "Tuna Steak", 13.5, 6 },
                    { 18, "Traditional grilled minced meat served with flatbread and chopped onion.", null, "Ćevapi with Onion", 6.5, 7 },
                    { 19, "Spicy Thai soup with shrimp, lemongrass, and chili.", null, "Tom Yum Soup", 7.5, 8 },
                    { 20, "French toasted sandwich with ham and melted cheese.", null, "Croque Monsieur", 6.0, 9 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CourierId", "CustomerId", "DeliveredAt", "DeliveryAddressId", "DeliveryStartedAt", "OrderTime", "RestaurantId", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", null, 1, null, null, 20, 0, 0.0 },
                    { 2, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02", null, 3, null, new DateTime(2025, 11, 23, 17, 31, 9, 956, DateTimeKind.Utc).AddTicks(9954), 19, 2, 0.0 },
                    { 3, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh16", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03", null, 4, null, null, 19, 0, 0.0 },
                    { 4, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh17", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04", null, 7, null, null, 18, 0, 0.0 },
                    { 5, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh18", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05", null, 8, null, null, 18, 0, 0.0 },
                    { 6, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh19", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh06", null, 10, null, null, 18, 0, 0.0 },
                    { 7, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh20", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07", null, 11, null, null, 19, 1, 0.0 },
                    { 8, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh21", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh08", null, 13, null, null, 20, 1, 0.0 },
                    { 9, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh22", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09", null, 14, null, null, 20, 4, 0.0 },
                    { 10, "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh23", "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh10", null, 16, null, new DateTime(2025, 11, 23, 17, 31, 9, 956, DateTimeKind.Utc).AddTicks(9964), 20, 4, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "MealAllergens",
                columns: new[] { "AllergenId", "MealId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 7 },
                    { 1, 9 },
                    { 1, 11 },
                    { 1, 13 },
                    { 1, 16 },
                    { 1, 18 },
                    { 1, 20 },
                    { 5, 19 },
                    { 8, 8 },
                    { 8, 9 },
                    { 8, 11 },
                    { 8, 13 },
                    { 9, 3 },
                    { 9, 6 },
                    { 9, 12 },
                    { 9, 17 },
                    { 9, 19 },
                    { 10, 2 },
                    { 10, 9 },
                    { 10, 10 },
                    { 10, 11 },
                    { 10, 13 },
                    { 10, 15 },
                    { 10, 18 },
                    { 10, 20 },
                    { 11, 8 },
                    { 12, 3 },
                    { 12, 5 },
                    { 12, 8 },
                    { 12, 14 },
                    { 12, 16 },
                    { 13, 10 },
                    { 22, 1 },
                    { 22, 7 },
                    { 22, 12 },
                    { 23, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06d0a7d8-e368-4d03-b2e3-5c7311cb7213");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3485de77-5faf-43b7-b7a2-9072370e4da4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39f14a74-4748-4068-9594-bd043a6450c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53f4f034-1bc2-459c-8711-f576165761a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b26f6d4c-4b97-435e-a9a1-25c0528a364a");

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 5, 19 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 9, 17 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 9, 19 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 15 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 18 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 10, 20 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 11, 8 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 12, 14 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 12, 16 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 13, 10 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 22, 7 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 22, 12 });

            migrationBuilder.DeleteData(
                table: "MealAllergens",
                keyColumns: new[] { "AllergenId", "MealId" },
                keyValues: new object[] { 23, 4 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

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
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27074fea-1afb-45ac-ad63-9145c8f9932a", null, "RestaurantOwner", "RESTAURANTOWNER" },
                    { "7b45c538-e69c-4a0a-a516-e1df644ecc0b", null, "Administrator", "ADMINISTRATOR" },
                    { "b7a2ffb0-3313-4338-8cec-46c78d71063b", null, "Employee", "EMPLOYEE" },
                    { "bda195a7-1532-4a80-a12a-c198dc4f38b2", null, "Courier", "COURIER" },
                    { "c2ce29bd-22cf-4558-94bb-b618e9a6902c", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
