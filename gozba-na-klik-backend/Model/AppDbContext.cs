﻿using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Addresses)
                .WithOne()
                .HasForeignKey(address => address.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Allergens)
                .WithMany("Customers")
                .UsingEntity<Dictionary<string, object>>(
                "CustomerAllergens",
                j => j.HasOne<Allergen>().WithMany().HasForeignKey("AllergenId").OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.Cascade)
                );

            modelBuilder.Entity<Meal>()
                .HasMany(meal => meal.Allergens)
                .WithMany("Meals")
                .UsingEntity<Dictionary<string, object>>(
                "MealAllergens",
                j=>j.HasOne<Allergen>().WithMany().HasForeignKey("AllergenId").OnDelete(DeleteBehavior.Cascade),
                j=>j.HasOne<Meal>().WithMany().HasForeignKey("MealId").OnDelete(DeleteBehavior.Cascade)
                );

            modelBuilder.Entity<Restaurant>()
                .HasMany(restaurant=> restaurant.MealsOnMenu)
                .WithOne()
                .HasForeignKey(restauant=>restauant.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>(entity =>
    {
        entity.HasKey(o => o.Id);

        entity.HasOne(o => o.Customer)
              .WithMany(c => c.Orders)
              .HasForeignKey(o => o.CustomerId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(o => o.Restaurant)
              .WithMany(r => r.Orders)
              .HasForeignKey(o => o.RestaurantId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.Property(o => o.OrderTime).IsRequired(false); 

        entity.Property(o => o.Status)
              .HasConversion<int>()
              .IsRequired();
    });

    // OrderMeal (join entity to track quantity)
    modelBuilder.Entity<OrderMeal>(entity =>
    {
        entity.HasKey(om => new { om.OrderId, om.MealId });

        entity.HasOne(om => om.Order)
              .WithMany(o => o.OrderItems)
              .HasForeignKey(om => om.OrderId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(om => om.Meal)
              .WithMany(m => m.OrderMeals)
              .HasForeignKey(om => om.MealId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.Property(om => om.Quantity).IsRequired();
    });


            modelBuilder.Entity<Administrator>().HasData(
                new Administrator { Id = 1, Name = "Ashley", Surname = "Diaz", Email = "walkerlaura@example.net", Username = "admin1", Password = "admin123", ProfileImageUrl = "https://example.com/admin1.png", ContactNumber = "+381601112223" },
                new Administrator { Id = 2, Name = "Michelle", Surname = "Nguyen", Email = "davidmullins@example.org", Username = "admin2", Password = "admin123", ProfileImageUrl = "https://example.com/admin2.png", ContactNumber = "+381611234567" },
                new Administrator { Id = 3, Name = "Robert", Surname = "Barton", Email = "andersonnicholas@example.com", Username = "admin3", Password = "admin123", ProfileImageUrl = "https://example.com/admin3.png", ContactNumber = "+381641234890" }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 4, Name = "Ashley", Surname = "Green", Email = "caseymaria@example.com", Username = "customer4", Password = "cust123", ProfileImageUrl = "https://example.com/customer4.png", ContactNumber = "+381621112223" },
                new Customer { Id = 5, Name = "Emily", Surname = "Austin", Email = "reynoldscourtney@example.net", Username = "customer5", Password = "cust123", ProfileImageUrl = "https://example.com/customer5.png", ContactNumber = "+381631234567" },
                new Customer { Id = 6, Name = "Wendy", Surname = "Vargas", Email = "michael99@example.org", Username = "customer6", Password = "cust123", ProfileImageUrl = "https://example.com/customer6.png", ContactNumber = "+381601234321" },
                new Customer { Id = 7, Name = "Kimberly", Surname = "Brown", Email = "robertschristopher@example.net", Username = "customer7", Password = "cust123", ProfileImageUrl = "https://example.com/customer7.png", ContactNumber = "+381641112233" },
                new Customer { Id = 8, Name = "David", Surname = "Sims", Email = "nelsonrebecca@example.com", Username = "customer8", Password = "cust123", ProfileImageUrl = "https://example.com/customer8.png", ContactNumber = "+381611231231" },
                new Customer { Id = 9, Name = "Christine", Surname = "Maldonado", Email = "matthew11@example.org", Username = "customer9", Password = "cust123", ProfileImageUrl = "https://example.com/customer9.png", ContactNumber = "+381621234890" },
                new Customer { Id = 10, Name = "William", Surname = "Huff", Email = "heathermartinez@example.org", Username = "customer10", Password = "cust123", ProfileImageUrl = "https://example.com/customer10.png", ContactNumber = "+381601113355" },
                new Customer { Id = 11, Name = "Ryan", Surname = "Bennett", Email = "linda83@example.com", Username = "customer11", Password = "cust123", ProfileImageUrl = "https://example.com/customer11.png", ContactNumber = "+381631234444" },
                new Customer { Id = 12, Name = "Sean", Surname = "Butler", Email = "stevensholly@example.org", Username = "customer12", Password = "cust123", ProfileImageUrl = "https://example.com/customer12.png", ContactNumber = "+381641112567" },
                new Customer { Id = 13, Name = "Timothy", Surname = "Horton", Email = "nelsonpaul@example.net", Username = "customer13", Password = "cust123", ProfileImageUrl = "https://example.com/customer13.png", ContactNumber = "+381611114455" }
            );

            modelBuilder.Entity<Courier>().HasData(
                new Courier { Id = 14, Name = "Jessica", Surname = "Nguyen", Email = "jameswells@example.net", Username = "courier14", Password = "courier123", ProfileImageUrl = "https://example.com/courier14.png", ContactNumber = "+381621234567" },
                new Courier { Id = 15, Name = "Samantha", Surname = "Jackson", Email = "turneremily@example.net", Username = "courier15", Password = "courier123", ProfileImageUrl = "https://example.com/courier15.png", ContactNumber = "+381631118889" },
                new Courier { Id = 16, Name = "Nicholas", Surname = "Mcdaniel", Email = "stephaniedavis@example.com", Username = "courier16", Password = "courier123", ProfileImageUrl = "https://example.com/courier16.png", ContactNumber = "+381601231111" },
                new Courier { Id = 17, Name = "Edward", Surname = "Morgan", Email = "laura66@example.net", Username = "courier17", Password = "courier123", ProfileImageUrl = "https://example.com/courier17.png", ContactNumber = "+381641112001" },
                new Courier { Id = 18, Name = "Tina", Surname = "Collins", Email = "aliciamurray@example.org", Username = "courier18", Password = "courier123", ProfileImageUrl = "https://example.com/courier18.png", ContactNumber = "+381611234678" },
                new Courier { Id = 19, Name = "Kimberly", Surname = "Schroeder", Email = "michael37@example.com", Username = "courier19", Password = "courier123", ProfileImageUrl = "https://example.com/courier19.png", ContactNumber = "+381621112999" },
                new Courier { Id = 20, Name = "Paul", Surname = "Owen", Email = "sarahhill@example.com", Username = "courier20", Password = "courier123", ProfileImageUrl = "https://example.com/courier20.png", ContactNumber = "+381631234001" },
                new Courier { Id = 21, Name = "Patricia", Surname = "Evans", Email = "keith54@example.com", Username = "courier21", Password = "courier123", ProfileImageUrl = "https://example.com/courier21.png", ContactNumber = "+381601118880" },
                new Courier { Id = 22, Name = "Kimberly", Surname = "Brock", Email = "jessicaduncan@example.org", Username = "courier22", Password = "courier123", ProfileImageUrl = "https://example.com/courier22.png", ContactNumber = "+381641113456" },
                new Courier { Id = 23, Name = "David", Surname = "Chavez", Email = "hannah67@example.org", Username = "courier23", Password = "courier123", ProfileImageUrl = "https://example.com/courier23.png", ContactNumber = "+381611231987" }
            );

            modelBuilder.Entity<RestaurantOwner>().HasData(
                new RestaurantOwner { Id = 24, Name = "Victor", Surname = "Diaz", Email = "victor.diaz@example.com", Username = "owner24", Password = "owner123", ProfileImageUrl = "https://example.com/owner24.png", ContactNumber = "+381621111234" },
                new RestaurantOwner { Id = 25, Name = "Laura", Surname = "Smith", Email = "laura.smith@example.com", Username = "owner25", Password = "owner123", ProfileImageUrl = "https://example.com/owner25.png", ContactNumber = "+381631234222" },
                new RestaurantOwner { Id = 26, Name = "James", Surname = "Johnson", Email = "james.johnson@example.com", Username = "owner26", Password = "owner123", ProfileImageUrl = "https://example.com/owner26.png", ContactNumber = "+381601118899" },
                new RestaurantOwner { Id = 27, Name = "Olivia", Surname = "Brown", Email = "olivia.brown@example.com", Username = "owner27", Password = "owner123", ProfileImageUrl = "https://example.com/owner27.png", ContactNumber = "+381641234654" },
                new RestaurantOwner { Id = 28, Name = "Ethan", Surname = "Williams", Email = "ethan.williams@example.com", Username = "owner28", Password = "owner123", ProfileImageUrl = "https://example.com/owner28.png", ContactNumber = "+381611112345" },
                new RestaurantOwner { Id = 29, Name = "Sophia", Surname = "Jones", Email = "sophia.jones@example.com", Username = "owner29", Password = "owner123", ProfileImageUrl = "https://example.com/owner29.png", ContactNumber = "+381621113333" },
                new RestaurantOwner { Id = 30, Name = "Mason", Surname = "Garcia", Email = "mason.garcia@example.com", Username = "owner30", Password = "owner123", ProfileImageUrl = "https://example.com/owner30.png", ContactNumber = "+381631112001" },
                new RestaurantOwner { Id = 31, Name = "Isabella", Surname = "Martinez", Email = "isabella.martinez@example.com", Username = "owner31", Password = "owner123", ProfileImageUrl = "https://example.com/owner31.png", ContactNumber = "+381601118123" },
                new RestaurantOwner { Id = 32, Name = "Logan", Surname = "Rodriguez", Email = "logan.rodriguez@example.com", Username = "owner32", Password = "owner123", ProfileImageUrl = "https://example.com/owner32.png", ContactNumber = "+381641231231" },
                new RestaurantOwner { Id = 33, Name = "Ava", Surname = "Lee", Email = "ava.lee@example.com", Username = "owner33", Password = "owner123", ProfileImageUrl = "https://example.com/owner33.png", ContactNumber = "+381611234432" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 34, Name = "Noah", Surname = "Walker", Email = "noah.walker@example.com", Username = "employee34", Password = "emp123", ProfileImageUrl = "https://example.com/employee34.png", ContactNumber = "+381621112777" },
                new Employee { Id = 35, Name = "Mia", Surname = "Hall", Email = "mia.hall@example.com", Username = "employee35", Password = "emp123", ProfileImageUrl = "https://example.com/employee35.png", ContactNumber = "+381631234123" },
                new Employee { Id = 36, Name = "Liam", Surname = "Allen", Email = "liam.allen@example.com", Username = "employee36", Password = "emp123", ProfileImageUrl = "https://example.com/employee36.png", ContactNumber = "+381601119900" },
                new Employee { Id = 37, Name = "Charlotte", Surname = "Young", Email = "charlotte.young@example.com", Username = "employee37", Password = "emp123", ProfileImageUrl = "https://example.com/employee37.png", ContactNumber = "+381641118765" },
                new Employee { Id = 38, Name = "Jacob", Surname = "Hernandez", Email = "jacob.hernandez@example.com", Username = "employee38", Password = "emp123", ProfileImageUrl = "https://example.com/employee38.png", ContactNumber = "+381611112888" },
                new Employee { Id = 39, Name = "Amelia", Surname = "King", Email = "amelia.king@example.com", Username = "employee39", Password = "emp123", ProfileImageUrl = "https://example.com/employee39.png", ContactNumber = "+381621112555" },
                new Employee { Id = 40, Name = "Evelyn", Surname = "Wright", Email = "evelyn.wright@example.com", Username = "employee40", Password = "emp123", ProfileImageUrl = "https://example.com/employee40.png", ContactNumber = "+381631119111" },
                new Employee { Id = 41, Name = "Alexander", Surname = "Lopez", Email = "alexander.lopez@example.com", Username = "employee41", Password = "emp123", ProfileImageUrl = "https://example.com/employee41.png", ContactNumber = "+381601113789" },
                new Employee { Id = 42, Name = "Ella", Surname = "Hill", Email = "ella.hill@example.com", Username = "employee42", Password = "emp123", ProfileImageUrl = "https://example.com/employee42.png", ContactNumber = "+381641112456" },
                new Employee { Id = 43, Name = "Michael", Surname = "Scott", Email = "michael.scott@example.com", Username = "employee43", Password = "emp123", ProfileImageUrl = "https://example.com/employee43.png", ContactNumber = "+381611231111" }
            );
            modelBuilder.Entity<Allergen>().HasData(
                new Allergen { Id = 1, Name = "wheat" },
                new Allergen { Id = 2, Name = "rye" },
                new Allergen { Id = 3, Name = "barley" },
                new Allergen { Id = 4, Name = "oats" },
                new Allergen { Id = 5, Name = "crabs" },
                new Allergen { Id = 6, Name = "lobsters" },
                new Allergen { Id = 7, Name = "prawns" },
                new Allergen { Id = 8, Name = "eggs" },
                new Allergen { Id = 9, Name = "fish" },
                new Allergen { Id = 10, Name = "milk" },
                new Allergen { Id = 11, Name = "peanuts" },
                new Allergen { Id = 12, Name = "soybean" },
                new Allergen { Id = 13, Name = "almonds" },
                new Allergen { Id = 14, Name = "hazelnuts" },
                new Allergen { Id = 15, Name = "walnuts" },
                new Allergen { Id = 16, Name = "cashews" },
                new Allergen { Id = 17, Name = "pecan nuts" },
                new Allergen { Id = 18, Name = "Brazil nuts" },
                new Allergen { Id = 19, Name = "pistachios" },
                new Allergen { Id = 20, Name = "macadamia nuts" },
                new Allergen { Id = 21, Name = "Queensland nuts" },
                new Allergen { Id = 22, Name = "celery" },
                new Allergen { Id = 23, Name = "mustard" },
                new Allergen { Id = 24, Name = "Lupin" },
                new Allergen { Id = 25, Name = "mussels" },
                new Allergen { Id = 26, Name = "oysters" },
                new Allergen { Id = 27, Name = "squid" }
                );

            modelBuilder.Entity<Address>().HasData(
                // Ashley (CustomerId = 4)
                new Address { Id = 1, Street = "Main Street", StreetNumber = 12, City = "Belgrade", ZipCode = "11000", CustomerId = 4 },
                new Address { Id = 2, Street = "Green Avenue", StreetNumber = 3, City = "Novi Sad", ZipCode = "21000", CustomerId = 4 },

                // Emily (CustomerId = 5)
                new Address { Id = 3, Street = "Sunset Blvd", StreetNumber = 44, City = "Niš", ZipCode = "18000", CustomerId = 5 },

                // Wendy (CustomerId = 6)
                new Address { Id = 4, Street = "Kralja Petra", StreetNumber = 8, City = "Belgrade", ZipCode = "11000", CustomerId = 6 },
                new Address { Id = 5, Street = "Vojvode Stepe", StreetNumber = 126, City = "Belgrade", ZipCode = "11010", CustomerId = 6 },
                new Address { Id = 6, Street = "Cara Dušana", StreetNumber = 22, City = "Zemun", ZipCode = "11080", CustomerId = 6 },

                // Kimberly (CustomerId = 7)
                new Address { Id = 7, Street = "Ruzveltova", StreetNumber = 33, City = "Belgrade", ZipCode = "11120", CustomerId = 7 },

                // David (CustomerId = 8)
                new Address { Id = 8, Street = "Bulevar Oslobođenja", StreetNumber = 99, City = "Novi Sad", ZipCode = "21000", CustomerId = 8 },
                new Address { Id = 9, Street = "Zmaj Jovina", StreetNumber = 11, City = "Novi Sad", ZipCode = "21000", CustomerId = 8 },

                // Christine (CustomerId = 9)
                new Address { Id = 10, Street = "Nemanjina", StreetNumber = 5, City = "Belgrade", ZipCode = "11000", CustomerId = 9 },

                // William (CustomerId = 10)
                new Address { Id = 11, Street = "Gogoljeva", StreetNumber = 15, City = "Subotica", ZipCode = "24000", CustomerId = 10 },
                new Address { Id = 12, Street = "Matije Gupca", StreetNumber = 2, City = "Subotica", ZipCode = "24000", CustomerId = 10 },

                // Ryan (CustomerId = 11)
                new Address { Id = 13, Street = "Partizanska", StreetNumber = 66, City = "Kragujevac", ZipCode = "34000", CustomerId = 11 },

                // Sean (CustomerId = 12)
                new Address { Id = 14, Street = "Vladimira Nazora", StreetNumber = 7, City = "Čačak", ZipCode = "32000", CustomerId = 12 },
                new Address { Id = 15, Street = "Trg Oslobođenja", StreetNumber = 1, City = "Čačak", ZipCode = "32000", CustomerId = 12 },

                // Timothy (CustomerId = 13)
                new Address { Id = 16, Street = "Industrijska", StreetNumber = 10, City = "Pančevo", ZipCode = "26000", CustomerId = 13 }
            );

            modelBuilder.Entity<Restaurant>().HasData(
                 new Restaurant { Id = 1, Name = "Bistro Nova", Address = "Kralja Petra 12", City = "Belgrade", Description = "Modern Serbian cuisine with a twist.", Capacity = 60, AverageRating = 6.5, RestaurantOwnerId = 24 },
                 new Restaurant { Id = 2, Name = "La Tavola", Address = "Cara Dušana 45", City = "Novi Sad", Description = "Authentic Italian trattoria.", Capacity = 80, AverageRating = 9.5, RestaurantOwnerId = 24 },
                 new Restaurant { Id = 3, Name = "Sakura Zen", Address = "Bulevar Oslobođenja 88", City = "Niš", Description = "Japanese sushi bar with minimalist ambiance.", Capacity = 40, AverageRating = 8.2, RestaurantOwnerId = 24 },
                 new Restaurant { Id = 4, Name = "Grill & Chill", Address = "Trg Slobode 3", City = "Subotica", Description = "American-style BBQ with craft beers.", Capacity = 100, AverageRating = 3.8, RestaurantOwnerId = 24 },
                 new Restaurant { Id = 5, Name = "Green Wave", Address = "Njegoševa 21", City = "Belgrade", Description = "Vegan restaurant with organic dishes.", Capacity = 50, AverageRating = 5, RestaurantOwnerId = 25 },
                 new Restaurant { Id = 6, Name = "Casa del Mar", Address = "Obala 7", City = "Herceg Novi", Description = "Mediterranean cuisine with a sea view.", Capacity = 90, AverageRating = 5, RestaurantOwnerId = 25 },
                 new Restaurant { Id = 7, Name = "Grandma's Kitchen", Address = "Vojvode Mišića 14", City = "Kragujevac", Description = "Traditional homemade Serbian food.", Capacity = 70, AverageRating = 5, RestaurantOwnerId = 26 },
                 new Restaurant { Id = 8, Name = "Urban Spoon", Address = "Zmaj Jovina 9", City = "Novi Sad", Description = "Fusion cuisine in a modern setting.", Capacity = 85, AverageRating = 5, RestaurantOwnerId = 27 },
                 new Restaurant { Id = 9, Name = "Le Petit Café", Address = "Francuska 5", City = "Belgrade", Description = "French bistro with croissants and wine.", Capacity = 45, AverageRating = 8, RestaurantOwnerId = 27 },
                 new Restaurant { Id = 10, Name = "Tandoori Flame", Address = "Đure Jakšića 33", City = "Zrenjanin", Description = "Indian cuisine with authentic spices.", Capacity = 60, AverageRating = 9, RestaurantOwnerId = 28 },
                 new Restaurant { Id = 11, Name = "Burger Lab", Address = "Miletićeva 18", City = "Pančevo", Description = "Gourmet burgers with homemade sauces.", Capacity = 55, AverageRating = 7, RestaurantOwnerId = 29 },
                 new Restaurant { Id = 12, Name = "Fish Pot", Address = "Dunavska 2", City = "Sombor", Description = "Seafood specialties and river fish.", Capacity = 75, AverageRating = 5, RestaurantOwnerId = 30 },
                 new Restaurant { Id = 13, Name = "Pasta Mia", Address = "Kneza Miloša 27", City = "Belgrade", Description = "Fresh pasta and Italian desserts.", Capacity = 65, AverageRating = 5.4, RestaurantOwnerId = 31 },
                 new Restaurant { Id = 14, Name = "Orient Express", Address = "Nikole Pašića 10", City = "Niš", Description = "Asian cuisine with wok and curry dishes.", Capacity = 80, AverageRating = 6.7, RestaurantOwnerId = 32 },
                 new Restaurant { Id = 15, Name = "Steakhouse 21", Address = "Bulevar Evrope 21", City = "Novi Sad", Description = "Premium steaks and fine wines.", Capacity = 95, AverageRating = 8.6, RestaurantOwnerId = 33 },
                 new Restaurant { Id = 16, Name = "Nest", Address = "Gundulićeva 6", City = "Belgrade", Description = "Rustic ambiance with local specialties.", Capacity = 70, AverageRating = 5, RestaurantOwnerId = 32 },
                 new Restaurant { Id = 17, Name = "Tapas Bar", Address = "Petrovaradinska 4", City = "Novi Sad", Description = "Spanish tapas and sangria.", Capacity = 60, AverageRating = 5, RestaurantOwnerId = 28 },
                 new Restaurant { Id = 18, Name = "Marko's Tavern", Address = "Glavna 1", City = "Valjevo", Description = "Authentic tavern with live folk music.", Capacity = 100, AverageRating = 5, RestaurantOwnerId = 28 },
                 new Restaurant { Id = 19, Name = "Thai Orchid", Address = "Vojvode Stepe 19", City = "Belgrade", Description = "Thai cuisine with exotic flavors.", Capacity = 50, AverageRating = 5, RestaurantOwnerId = 29 },
                 new Restaurant { Id = 20, Name = "Nordic Table", Address = "Skandinavska 3", City = "Novi Sad", Description = "Nordic cuisine with minimalist design.", Capacity = 40, AverageRating = 5, RestaurantOwnerId = 30 }
             );

            modelBuilder.Entity<Meal>().HasData(
                new Meal { Id = 1, MealName = "Stuffed Peppers", Description = "Homemade peppers stuffed with minced meat and rice.", Price = 6.5, MealImageUrl = null, RestaurantId = 1 },
                new Meal { Id = 2, MealName = "Capricciosa Pizza", Description = "Classic pizza with ham, mushrooms, and cheese.", Price = 8.0, MealImageUrl = null, RestaurantId = 2 },
                new Meal { Id = 3, MealName = "Sushi Mix", Description = "Assorted nigiri, maki, and sashimi rolls.", Price = 12.5, MealImageUrl = null, RestaurantId = 3 },
                new Meal { Id = 4, MealName = "BBQ Ribs", Description = "Smoked pork ribs with homemade BBQ sauce.", Price = 14.0, MealImageUrl = null, RestaurantId = 4 },
                new Meal { Id = 5, MealName = "Falafel Bowl", Description = "Vegan bowl with falafel, hummus, and fresh veggies.", Price = 7.5, MealImageUrl = null, RestaurantId = 5 },
                new Meal { Id = 6, MealName = "Grilled Sea Bream", Description = "Fresh sea bream with lemon and herbs.", Price = 13.0, MealImageUrl = null, RestaurantId = 6 },
                new Meal { Id = 7, MealName = "Cabbage Rolls", Description = "Traditional Serbian rolls with meat and rice.", Price = 6.0, MealImageUrl = null, RestaurantId = 7 },
                new Meal { Id = 8, MealName = "Pad Thai", Description = "Thai noodles with peanuts, eggs, and vegetables.", Price = 9.5, MealImageUrl = null, RestaurantId = 8 },
                new Meal { Id = 9, MealName = "Quiche Lorraine", Description = "French tart with eggs, cheese, and bacon.", Price = 7.0, MealImageUrl = null, RestaurantId = 9 },
                new Meal { Id = 10, MealName = "Chicken Tikka Masala", Description = "Chicken in creamy Indian tomato sauce.", Price = 10.5, MealImageUrl = null, RestaurantId = 10 },
                new Meal { Id = 11, MealName = "Classic Burger", Description = "Beef burger with cheese, lettuce, and sauce.", Price = 8.5, MealImageUrl = null, RestaurantId = 1 },
                new Meal { Id = 12, MealName = "Fish Soup", Description = "Traditional soup made from river fish.", Price = 5.5, MealImageUrl = null, RestaurantId = 6 },
                new Meal { Id = 13, MealName = "Pasta Carbonara", Description = "Pasta with pancetta, eggs, and parmesan.", Price = 9.0, MealImageUrl = null, RestaurantId = 2 },
                new Meal { Id = 14, MealName = "Wok Veggies", Description = "Mixed vegetables stir-fried in soy sauce.", Price = 7.0, MealImageUrl = null, RestaurantId = 8 },
                new Meal { Id = 15, MealName = "Peppercorn Steak", Description = "Premium beef steak with creamy pepper sauce.", Price = 15.5, MealImageUrl = null, RestaurantId = 4 },
                new Meal { Id = 16, MealName = "Vegan Lasagna", Description = "Lasagna with zucchini, eggplant, and tofu.", Price = 8.0, MealImageUrl = null, RestaurantId = 5 },
                new Meal { Id = 17, MealName = "Tuna Steak", Description = "Grilled tuna fillet with lime and arugula.", Price = 13.5, MealImageUrl = null, RestaurantId = 6 },
                new Meal { Id = 18, MealName = "Ćevapi with Onion", Description = "Traditional grilled minced meat served with flatbread and chopped onion.", Price = 6.5, MealImageUrl = null, RestaurantId = 7 },
                new Meal { Id = 19, MealName = "Tom Yum Soup", Description = "Spicy Thai soup with shrimp, lemongrass, and chili.", Price = 7.5, MealImageUrl = null, RestaurantId = 8 },
                new Meal { Id = 20, MealName = "Croque Monsieur", Description = "French toasted sandwich with ham and melted cheese.", Price = 6.0, MealImageUrl = null, RestaurantId = 9 }
                );
            modelBuilder.Entity<Order>().HasData(
    new Order { Id = 1, CustomerId = 4, RestaurantId = 20, OrderTime = null, Status = OrderStatus.NaCekanju },
    new Order { Id = 2, CustomerId = 5, RestaurantId = 19, OrderTime = new TimeSpan(14, 30, 0), Status = OrderStatus.Otkazana },
    new Order { Id = 3, CustomerId = 6, RestaurantId = 19, OrderTime = null, Status = OrderStatus.NaCekanju },
    new Order { Id = 4, CustomerId = 7, RestaurantId = 18, OrderTime = null, Status = OrderStatus.NaCekanju },
    new Order { Id = 5, CustomerId = 8, RestaurantId = 18, OrderTime = null, Status = OrderStatus.NaCekanju },
    new Order { Id = 6, CustomerId = 9, RestaurantId = 18, OrderTime = null, Status = OrderStatus.NaCekanju },
    new Order { Id = 7, CustomerId = 10, RestaurantId = 19, OrderTime = null, Status = OrderStatus.NaCekanju },
    new Order { Id = 8, CustomerId = 11, RestaurantId = 20, OrderTime = null, Status = OrderStatus.NaCekanju },
    new Order { Id = 9, CustomerId = 12, RestaurantId = 20, OrderTime = null, Status = OrderStatus.NaCekanju },
    new Order { Id = 10, CustomerId = 13, RestaurantId = 20, OrderTime = new TimeSpan(14, 30, 0), Status = OrderStatus.Otkazana }
);

            // OrderMeals (join table for meals + quantity)
            modelBuilder.Entity<OrderMeal>().HasData(
                new OrderMeal { OrderId = 1, MealId = 1, Quantity = 2 },
                new OrderMeal { OrderId = 1, MealId = 11, Quantity = 1 },
                new OrderMeal { OrderId = 2, MealId = 1, Quantity = 1 },
                new OrderMeal { OrderId = 2, MealId = 11, Quantity = 1 },
                new OrderMeal { OrderId = 3, MealId = 1, Quantity = 3 },
                new OrderMeal { OrderId = 4, MealId = 2, Quantity = 2 },
                new OrderMeal { OrderId = 4, MealId = 13, Quantity = 1 },
                new OrderMeal { OrderId = 5, MealId = 2, Quantity = 1 },
                new OrderMeal { OrderId = 5, MealId = 13, Quantity = 2 },
                new OrderMeal { OrderId = 6, MealId = 3, Quantity = 2 },
                new OrderMeal { OrderId = 7, MealId = 3, Quantity = 1 },
                new OrderMeal { OrderId = 8, MealId = 4, Quantity = 3 },
                new OrderMeal { OrderId = 9, MealId = 4, Quantity = 2 },
                new OrderMeal { OrderId = 10, MealId = 4, Quantity = 1 }
            );
            modelBuilder.Entity("MealAllergens").HasData(
                // Jelo 1: Stuffed Peppers (Id=1) - Pšenica (1), Celer (22)
                new { MealId = 1, AllergenId = 1 },
                new { MealId = 1, AllergenId = 22 },

                // Jelo 2: Capricciosa Pizza (Id=2) - Pšenica (1), Mleko (10)
                new { MealId = 2, AllergenId = 1 },
                new { MealId = 2, AllergenId = 10 },

                // Jelo 3: Sushi Mix (Id=3) - Riba (9), Soja (12)
                new { MealId = 3, AllergenId = 9 },
                new { MealId = 3, AllergenId = 12 },

                // Jelo 4: BBQ Ribs (Id=4) - Senf (23) (u sosu), Pšenica (1) (u marinadi/hleb)
                new { MealId = 4, AllergenId = 23 },
                new { MealId = 4, AllergenId = 1 },

                // Jelo 5: Falafel Bowl (Id=5) - Pšenica (1) (u falafelu ili lepinji)
                new { MealId = 5, AllergenId = 1 },
                new { MealId = 5, AllergenId = 12 }, // Soja

                // Jelo 6: Grilled Sea Bream (Id=6) - Riba (9)
                new { MealId = 6, AllergenId = 9 },

                // Jelo 7: Cabbage Rolls (Id=7) - Pšenica (1), Celer (22)
                new { MealId = 7, AllergenId = 1 },
                new { MealId = 7, AllergenId = 22 },

                // Jelo 8: Pad Thai (Id=8) - Kikiriki (11), Jaja (8), Soja (12)
                new { MealId = 8, AllergenId = 11 },
                new { MealId = 8, AllergenId = 8 },
                new { MealId = 8, AllergenId = 12 },

                // Jelo 9: Quiche Lorraine (Id=9) - Pšenica (1), Jaja (8), Mleko (10)
                new { MealId = 9, AllergenId = 1 },
                new { MealId = 9, AllergenId = 8 },
                new { MealId = 9, AllergenId = 10 },

                // Jelo 10: Chicken Tikka Masala (Id=10) - Mleko (10) (u jogurtu/sosu), Bademi (13) (ukras)
                new { MealId = 10, AllergenId = 10 },
                new { MealId = 10, AllergenId = 13 },

                // Jelo 11: Classic Burger (Id=11) - Pšenica (1) (zemička), Mleko (10) (sir/sos), Jaja (8) (majonez)
                new { MealId = 11, AllergenId = 1 },
                new { MealId = 11, AllergenId = 10 },
                new { MealId = 11, AllergenId = 8 },

                // Jelo 12: Fish Soup (Id=12) - Riba (9), Celer (22)
                new { MealId = 12, AllergenId = 9 },
                new { MealId = 12, AllergenId = 22 },

                // Jelo 13: Pasta Carbonara (Id=13) - Pšenica (1), Jaja (8), Mleko (10)
                new { MealId = 13, AllergenId = 1 },
                new { MealId = 13, AllergenId = 8 },
                new { MealId = 13, AllergenId = 10 },

                // Jelo 14: Wok Veggies (Id=14) - Soja (12)
                new { MealId = 14, AllergenId = 12 },

                // Jelo 15: Peppercorn Steak (Id=15) - Mleko (10) (u sosu)
                new { MealId = 15, AllergenId = 10 },

                // Jelo 16: Vegan Lasagna (Id=16) - Pšenica (1), Soja (12) (u tofuu/zameni za sir)
                new { MealId = 16, AllergenId = 1 },
                new { MealId = 16, AllergenId = 12 },

                // Jelo 17: Tuna Steak (Id=17) - Riba (9)
                new { MealId = 17, AllergenId = 9 },

                // Jelo 18: Ćevapi with Onion (Id=18) - Pšenica (1) (u hlebu)
                new { MealId = 18, AllergenId = 1 },
                new { MealId = 18, AllergenId = 10 }, // Mleko (ako se koristi kajmak)

                // Jelo 19: Tom Yum Soup (Id=19) - Škampi (5, iz grupe rakovi), Riba (9) (riblji sos)
                new { MealId = 19, AllergenId = 5 },
                new { MealId = 19, AllergenId = 9 },

                // Jelo 20: Croque Monsieur (Id=20) - Pšenica (1), Mleko (10)
                new { MealId = 20, AllergenId = 1 },
                new { MealId = 20, AllergenId = 10 }
            );

        }
    }
}
