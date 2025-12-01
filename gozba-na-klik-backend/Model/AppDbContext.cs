using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RestaurantOwner> RestaurantOwners { get; set; }
        public DbSet<OrderReview> OrderReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
            new IdentityRole { Name = "Courier", NormalizedName = "COURIER" },
            new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER" },
            new IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE" },
            new IdentityRole { Name = "RestaurantOwner", NormalizedName = "RESTAURANTOWNER" }
            );

            modelBuilder.Entity<IdentityUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

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
                j => j.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.Property<string>("CustomerId");
                    j.Property<int>("AllergenId");
                }
                );

            modelBuilder.Entity<Meal>()
                .HasMany(meal => meal.Allergens)
                .WithMany("Meals")
                .UsingEntity<Dictionary<string, object>>(
                "MealAllergens",
                j => j.HasOne<Allergen>().WithMany().HasForeignKey("AllergenId").OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Meal>().WithMany().HasForeignKey("MealId").OnDelete(DeleteBehavior.Cascade)
                );

            modelBuilder.Entity<Restaurant>()
                .HasMany(restaurant => restaurant.MealsOnMenu)
                .WithOne()
                .HasForeignKey(restauant => restauant.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.HasOne(o => o.Customer)
                      .WithMany()
                      .HasForeignKey(o => o.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                // ⭐ FIXED: Tell EF this is the 1-to-many Restaurant → Orders relationship
                entity.HasOne(o => o.Restaurant)
                      .WithMany(r => r.Orders)   // ⭐ IMPORTANT!
                      .HasForeignKey(o => o.RestaurantId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.Courier)
                      .WithMany(c => c.Orders)
                      .HasForeignKey(o => o.CourierId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.Property(o => o.OrderTime).IsRequired(false);

                entity.Property(o => o.Status)
                      .HasConversion<int>()
                      .IsRequired();
            });

            // One-to-one Order ↔ OrderReview
            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderReview)
                .WithOne(or => or.Order)
                .HasForeignKey<OrderReview>(or => or.OrderId);



            // OrderMeal (join entity to track quantity)
            modelBuilder.Entity<OrderMeal>(entity =>
            {
                entity.HasKey(om => new { om.OrderId, om.MealId });

                entity.HasOne(om => om.Meal)
                 .WithMany()
                 .HasForeignKey(om => om.MealId)
                 .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne<Order>()
                      .WithMany(o => o.OrderItems)
                      .HasForeignKey(om => om.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(om => om.Quantity).IsRequired();
            });


            modelBuilder.Entity<Administrator>().HasKey(a => a.Id);

            modelBuilder.Entity<Administrator>()
                .HasOne(a => a.ApplicationUser)
                .WithOne()
                .HasForeignKey<Administrator>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>().HasKey(c => c.Id);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.ApplicationUser)
                .WithOne()
                .HasForeignKey<Customer>(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Courier>().HasKey(cu => cu.Id);

            modelBuilder.Entity<Courier>()
                .HasOne(cu => cu.ApplicationUser)
                .WithOne()
                .HasForeignKey<Courier>(cu => cu.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>().HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ApplicationUser)
                .WithOne()
                .HasForeignKey<Employee>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RestaurantOwner>().HasKey(ro => ro.Id);

            modelBuilder.Entity<RestaurantOwner>()
                .HasOne(ro => ro.ApplicationUser)
                .WithOne()
                .HasForeignKey<RestaurantOwner>(ro => ro.Id)
                .OnDelete(DeleteBehavior.Cascade);
       
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

                  new Address
                  {
                      Id = 1,
                      Street = "Main Street",
                      StreetNumber = 12,
                      City = "Belgrade",
                      ZipCode = "11000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01"
                  },
                  new Address
                  {
                      Id = 2,
                      Street = "Green Avenue",
                      StreetNumber = 3,
                      City = "Novi Sad",
                      ZipCode = "21000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01"
                  },


                  new Address
                  {
                      Id = 3,
                      Street = "Sunset Blvd",
                      StreetNumber = 44,
                      City = "Niš",
                      ZipCode = "18000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02"
                  },


                  new Address
                  {
                      Id = 4,
                      Street = "Kralja Petra",
                      StreetNumber = 8,
                      City = "Belgrade",
                      ZipCode = "11000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03"
                  },
                  new Address
                  {
                      Id = 5,
                      Street = "Vojvode Stepe",
                      StreetNumber = 126,
                      City = "Belgrade",
                      ZipCode = "11010",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03"
                  },
                  new Address
                  {
                      Id = 6,
                      Street = "Cara Dušana",
                      StreetNumber = 22,
                      City = "Zemun",
                      ZipCode = "11080",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03"
                  },


                  new Address
                  {
                      Id = 7,
                      Street = "Ruzveltova",
                      StreetNumber = 33,
                      City = "Belgrade",
                      ZipCode = "11120",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04"
                  },


                  new Address
                  {
                      Id = 8,
                      Street = "Bulevar Oslobođenja",
                      StreetNumber = 99,
                      City = "Novi Sad",
                      ZipCode = "21000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05"
                  },
                  new Address
                  {
                      Id = 9,
                      Street = "Zmaj Jovina",
                      StreetNumber = 11,
                      City = "Novi Sad",
                      ZipCode = "21000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05"
                  },


                  new Address
                  {
                      Id = 10,
                      Street = "Nemanjina",
                      StreetNumber = 5,
                      City = "Belgrade",
                      ZipCode = "11000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh06"
                  },


                  new Address
                  {
                      Id = 11,
                      Street = "Gogoljeva",
                      StreetNumber = 15,
                      City = "Subotica",
                      ZipCode = "24000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07"
                  },
                  new Address
                  {
                      Id = 12,
                      Street = "Matije Gupca",
                      StreetNumber = 2,
                      City = "Subotica",
                      ZipCode = "24000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07"
                  },


                  new Address
                  {
                      Id = 13,
                      Street = "Partizanska",
                      StreetNumber = 66,
                      City = "Kragujevac",
                      ZipCode = "34000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh08"
                  },


                  new Address
                  {
                      Id = 14,
                      Street = "Vladimira Nazora",
                      StreetNumber = 7,
                      City = "Čačak",
                      ZipCode = "32000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09"
                  },
                  new Address
                  {
                      Id = 15,
                      Street = "Trg Oslobođenja",
                      StreetNumber = 1,
                      City = "Čačak",
                      ZipCode = "32000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09"
                  },

                  new Address
                  {
                      Id = 16,
                      Street = "Industrijska",
                      StreetNumber = 10,
                      City = "Pančevo",
                      ZipCode = "26000",
                      CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh10"
                  }
             );

            modelBuilder.Entity<Restaurant>().HasData(
                 new Restaurant
                 {
                     Id = 1,
                     Name = "Bistro Nova",
                     Address = "Kralja Petra 12",
                     City = "Belgrade",
                     Description = "Modern Serbian cuisine with a twist.",
                     Capacity = 60,
                     AverageRating = 6.5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760980868/1701656104-Le-Petiti-Bistro-Blue-Centar-13_adciqg.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24"
                 },
                 new Restaurant
                 {
                     Id = 2,
                     Name = "La Tavola",
                     Address = "Cara Dušana 45",
                     City = "Novi Sad",
                     Description = "Authentic Italian trattoria.",
                     Capacity = 80,
                     AverageRating = 9.5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981334/caption_e52wiq.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24"
                 },
                 new Restaurant
                 {
                     Id = 3,
                     Name = "Sakura Zen",
                     Address = "Bulevar Oslobođenja 88",
                     City = "Niš",
                     Description = "Japanese sushi bar with minimalist ambiance.",
                     Capacity = 40,
                     AverageRating = 8.2,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981371/348s_o6zhl9.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24"
                 },
                 new Restaurant
                 {
                     Id = 4,
                     Name = "Grill & Chill",
                     Address = "Trg Slobode 3",
                     City = "Subotica",
                     Description = "American-style BBQ with craft beers.",
                     Capacity = 100,
                     AverageRating = 3.8,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981740/348s_jvrtl3.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24"
                 },
                 new Restaurant
                 {
                     Id = 5,
                     Name = "Green Wave",
                     Address = "Njegoševa 21",
                     City = "Belgrade",
                     Description = "Vegan restaurant with organic dishes.",
                     Capacity = 50,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981837/AC9h4noKhAJV-_f5ucmgN7g1uu9vls7RQwFmyblYG2NoZPvK95_Go_jejqToiFswNCJ4-_fS2fTYgpCI5WdS_gfmLhjPLdx3iAPbXUCdeikQHC9o-ZPvLnI8UwM-jWS6mxXZ_bgEMXao_s680-w680-h510-rw_jdbfsp.webp",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh25"
                 },
                 new Restaurant
                 {
                     Id = 6,
                     Name = "Casa del Mar",
                     Address = "Obala 7",
                     City = "Herceg Novi",
                     Description = "Mediterranean cuisine with a sea view.",
                     Capacity = 90,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981920/LaDama_10881_20_1_ojaujg.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh25"
                 },
                 new Restaurant
                 {
                     Id = 7,
                     Name = "Grandma's Kitchen",
                     Address = "Vojvode Mišića 14",
                     City = "Kragujevac",
                     Description = "Traditional homemade Serbian food.",
                     Capacity = 70,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981760/im-65599456_e7zznz.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh26"
                 },
                 new Restaurant
                 {
                     Id = 8,
                     Name = "Urban Spoon",
                     Address = "Zmaj Jovina 9",
                     City = "Novi Sad",
                     Description = "Fusion cuisine in a modern setting.",
                     Capacity = 85,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760982086/5dc498fe695b58645d6f1dbc_jexb15.png",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh27"
                 },
                 new Restaurant
                 {
                     Id = 9,
                     Name = "Le Petit Café",
                     Address = "Francuska 5",
                     City = "Belgrade",
                     Description = "French bistro with croissants and wine.",
                     Capacity = 45,
                     AverageRating = 8,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981871/images_yybf2j.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh27"
                 },
                 new Restaurant
                 {
                     Id = 10,
                     Name = "Tandoori Flame",
                     Address = "Đure Jakšića 33",
                     City = "Zrenjanin",
                     Description = "Indian cuisine with authentic spices.",
                     Capacity = 60,
                     AverageRating = 9,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985797/a-chef-is-cooking-in-his-restaurants-kitchen_gfpjj0.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh28"
                 },
                 new Restaurant
                 {
                     Id = 11,
                     Name = "Burger Lab",
                     Address = "Miletićeva 18",
                     City = "Pančevo",
                     Description = "Gourmet burgers with homemade sauces.",
                     Capacity = 55,
                     AverageRating = 7,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985725/premium_photo-1661883237884-263e8de8869b_fhmc5u.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh29"
                 },
                 new Restaurant
                 {
                     Id = 12,
                     Name = "Fish Pot",
                     Address = "Dunavska 2",
                     City = "Sombor",
                     Description = "Seafood specialties and river fish.",
                     Capacity = 75,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760981672/348s_gedljh.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh30"
                 },
                 new Restaurant
                 {
                     Id = 13,
                     Name = "Pasta Mia",
                     Address = "Kneza Miloša 27",
                     City = "Belgrade",
                     Description = "Fresh pasta and Italian desserts.",
                     Capacity = 65,
                     AverageRating = 5.4,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985883/348s_fheyvs.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh31"
                 },
                 new Restaurant
                 {
                     Id = 14,
                     Name = "Orient Express",
                     Address = "Nikole Pašića 10",
                     City = "Niš",
                     Description = "Asian cuisine with wok and curry dishes.",
                     Capacity = 80,
                     AverageRating = 6.7,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985977/348s_pumoab.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh32"
                 },
                 new Restaurant
                 {
                     Id = 15,
                     Name = "Steakhouse 21",
                     Address = "Bulevar Evrope 21",
                     City = "Novi Sad",
                     Description = "Premium steaks and fine wines.",
                     Capacity = 95,
                     AverageRating = 8.6,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760986014/ejhsj8xcmjuwdsi8qdmj.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh33"
                 },
                 new Restaurant
                 {
                     Id = 16,
                     Name = "Nest",
                     Address = "Gundulićeva 6",
                     City = "Belgrade",
                     Description = "Rustic ambiance with local specialties.",
                     Capacity = 70,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985649/Most_Beautiful_Restaurants_scotland_December23_PR_Global_pafswr.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh32"
                 },
                 new Restaurant
                 {
                     Id = 17,
                     Name = "Tapas Bar",
                     Address = "Petrovaradinska 4",
                     City = "Novi Sad",
                     Description = "Spanish tapas and sangria.",
                     Capacity = 60,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760970771/slikaRestorana1_hibuiy.png",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh28"
                 },
                 new Restaurant
                 {
                     Id = 18,
                     Name = "Marko's Tavern",
                     Address = "Glavna 1",
                     City = "Valjevo",
                     Description = "Authentic tavern with live folk music.",
                     Capacity = 100,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760985542/07best-restaurants-nashville15-jbkq-videoSixteenByNineJumbo1600_ns15cb.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh28"
                 },
                 new Restaurant
                 {
                     Id = 19,
                     Name = "Thai Orchid",
                     Address = "Vojvode Stepe 19",
                     City = "Belgrade",
                     Description = "Thai cuisine with exotic flavors.",
                     Capacity = 50,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760986076/ix3atyp8yzjh6a25r2ms.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh29"
                 },
                 new Restaurant
                 {
                     Id = 20,
                     Name = "Nordic Table",
                     Address = "Skandinavska 3",
                     City = "Novi Sad",
                     Description = "Nordic cuisine with minimalist design.",
                     Capacity = 40,
                     AverageRating = 5,
                     RestaurantImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1760986113/Hakkaiza-industrial-restaurant-design2_vyopcv.jpg",
                     RestaurantOwnerId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh30"
                 }
             );

            modelBuilder.Entity<Meal>().HasData(
                new Meal { Id = 1, MealName = "Stuffed Peppers", Description = "Homemade peppers stuffed with minced meat and rice.", Price = 6.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219190/Stuffed_20Peppers_20-_20NCBA_20Beef_20Aug_20202431717_zkimq0.jpg", RestaurantId = 1 },
                new Meal { Id = 2, MealName = "Capricciosa Pizza", Description = "Classic pizza with ham, mushrooms, and cheese.", Price = 8.0, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219263/Pizza-Capricciosa_8_raj5pt.jpg", RestaurantId = 2 },
                new Meal { Id = 3, MealName = "Sushi Mix", Description = "Assorted nigiri, maki, and sashimi rolls.", Price = 12.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219415/omatsuri-2_c0esac.jpg", RestaurantId = 3 },
                new Meal { Id = 4, MealName = "BBQ Ribs", Description = "Smoked pork ribs with homemade BBQ sauce.", Price = 14.0, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219452/Barbecue-Ribs-Recipe-7_ikifom.jpg", RestaurantId = 4 },
                new Meal { Id = 5, MealName = "Falafel Bowl", Description = "Vegan bowl with falafel, hummus, and fresh veggies.", Price = 7.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219475/Bol_falafels_a18c8367-1a60-4132-8e78-0f8a3f363288_p2ayhu.jpg", RestaurantId = 5 },
                new Meal { Id = 6, MealName = "Grilled Sea Bream", Description = "Fresh sea bream with lemon and herbs.", Price = 13.0, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219536/Gegrillte-Dorade-Rezept-ELAG-Grillplatte-Induktionskochfeld-2020-1-2_elvevn.jpg", RestaurantId = 6 },
                new Meal { Id = 7, MealName = "Cabbage Rolls", Description = "Traditional Serbian rolls with meat and rice.", Price = 6.0, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219553/image_vb4wvf.jpg", RestaurantId = 7 },
                new Meal { Id = 8, MealName = "Pad Thai", Description = "Thai noodles with peanuts, eggs, and vegetables.", Price = 9.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219579/Authentic-Pad-Thai_square-1908_tufobi.jpg", RestaurantId = 8 },
                new Meal { Id = 9, MealName = "Quiche Lorraine", Description = "French tart with eggs, cheese, and bacon.", Price = 7.0, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219644/8-quiche-500x500_uvgs6y.webp", RestaurantId = 9 },
                new Meal { Id = 10, MealName = "Chicken Tikka Masala", Description = "Chicken in creamy Indian tomato sauce.", Price = 10.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219669/Chicken-Tikka-Masala_0-SQ_cqaxop.jpg", RestaurantId = 10 },
                new Meal { Id = 11, MealName = "Classic Burger", Description = "Beef burger with cheese, lettuce, and sauce.", Price = 8.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219720/frenchs_burger_styled-image_800x800_pqivq6.png", RestaurantId = 1 },
                new Meal { Id = 12, MealName = "Fish Soup", Description = "Traditional soup made from river fish.", Price = 5.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219766/fish-soup-in-a-white-bowl-square-e1691445762883_pvfccd.jpg", RestaurantId = 6 },
                new Meal { Id = 13, MealName = "Pasta Carbonara", Description = "Pasta with pancetta, eggs, and parmesan.", Price = 9.0, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219822/Spaghetti-carbonara-1-500x500_ummyjp.jpg", RestaurantId = 2 },
                new Meal { Id = 14, MealName = "Wok Veggies", Description = "Mixed vegetables stir-fried in soy sauce.", Price = 7.0, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219892/vegetable_stir_fry_hn87jz.jpg", RestaurantId = 8 },
                new Meal { Id = 15, MealName = "Peppercorn Steak", Description = "Premium beef steak with creamy pepper sauce.", Price = 15.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219939/Peppercorn-Steak_ae5dkp.jpg", RestaurantId = 4 },
                new Meal { Id = 16, MealName = "Vegan Lasagna", Description = "Lasagna with zucchini, eggplant, and tofu.", Price = 8.0, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761219985/Vegan-Lasagna-17_sq4o7j.jpg", RestaurantId = 5 },
                new Meal { Id = 17, MealName = "Tuna Steak", Description = "Grilled tuna fillet with lime and arugula.", Price = 13.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761220032/close-up-of-grilled-sliced-tuna-steak-medium-rare-1_zpdonx.jpg", RestaurantId = 6 },
                new Meal { Id = 18, MealName = "Ćevapi with Onion", Description = "Traditional grilled minced meat served with flatbread and chopped onion.", Price = 6.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761220073/cevapi-with-onion-on-oval-plater-middle-eastern-cuisine-salad-plates-and-lavash-bread_tlphkv.jpg", RestaurantId = 7 },
                new Meal { Id = 19, MealName = "Tom Yum Soup", Description = "Spicy Thai soup with shrimp, lemongrass, and chili.", Price = 7.5, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761220108/Tom-Yum-soup_2_ti1rim.jpg", RestaurantId = 8 },
                new Meal { Id = 20, MealName = "Croque Monsieur", Description = "French toasted sandwich with ham and melted cheese.", Price = 6.0, MealImageUrl = "https://res.cloudinary.com/dsgans7nh/image/upload/v1761220177/croque-monsieur-66a219aa5f0b2.jpg_h29478.jpg", RestaurantId = 9 }
            );

            modelBuilder.Entity<Order>().HasData(
                 new Order
                 {
                     Id = 1,
                     // Customer 4 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01",
                     RestaurantId = 20,
                     DeliveryAddressId = 1,
                     // Courier 14 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14",
                     OrderTime = null,
                     Status = OrderStatus.Pending
                 },
                 new Order
                 {
                     Id = 11,
                     // Customer 4 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01",
                     RestaurantId = 20,
                     DeliveryAddressId = 1,
                     // Courier 14 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14",
                     OrderTime = null,
                     Status = OrderStatus.Delivered
                 },
                 new Order
                 {
                     Id = 12,
                     // Customer 4 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01",
                     RestaurantId = 20,
                     DeliveryAddressId = 1,
                     // Courier 14 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14",
                     OrderTime = null,
                     Status = OrderStatus.Delivered
                 },
                 new Order
                 {
                     Id = 13,
                     // Customer 5 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02",
                     RestaurantId = 19,
                     DeliveryAddressId = 3,
                     // Courier 15 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15",
                     OrderTime = DateTime.UtcNow,
                     Status = OrderStatus.Delivered
                 },
                 new Order
                 {
                     Id = 3,
                     // Customer 6 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03",
                     RestaurantId = 19,
                     DeliveryAddressId = 4,
                     // Courier 16 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh16
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh16",
                     OrderTime = null,
                     Status = OrderStatus.Pending
                 },
                 new Order
                 {
                     Id = 4,
                     // Customer 7 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04",
                     RestaurantId = 18,
                     DeliveryAddressId = 7,
                     // Courier 17 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh17
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh17",
                     OrderTime = null,
                     Status = OrderStatus.Pending
                 },
                 new Order
                 {
                     Id = 5,
                     // Customer 8 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh05",
                     RestaurantId = 18,
                     DeliveryAddressId = 8,
                     // Courier 18 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh18
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh18",
                     OrderTime = null,
                     Status = OrderStatus.Pending
                 },
                 new Order
                 {
                     Id = 6,
                     // Customer 9 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh06
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh06",
                     RestaurantId = 18,
                     DeliveryAddressId = 10,
                     // Courier 19 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh19
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh19",
                     OrderTime = null,
                     Status = OrderStatus.Pending
                 },
                 new Order
                 {
                     Id = 7,
                     // Customer 10 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh07",
                     RestaurantId = 19,
                     DeliveryAddressId = 11,
                     // Courier 20 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh20
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh20",
                     OrderTime = null,
                     Status = OrderStatus.Accepted
                 },
                 new Order
                 {
                     Id = 8,
                     // Customer 11 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh08
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh08",
                     RestaurantId = 20,
                     DeliveryAddressId = 13,
                     // Courier 21 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh21
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh21",
                     OrderTime = null,
                     Status = OrderStatus.Accepted
                 },
                 new Order
                 {
                     Id = 9,
                     // Customer 12 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh09",
                     RestaurantId = 20,
                     DeliveryAddressId = 14,
                     // Courier 22 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh22
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh22",
                     OrderTime = null,
                     Status = OrderStatus.DeliveryInProgress
                 },
                 new Order
                 {
                     Id = 10,
                     // Customer 13 -> f1a2b3c4-d5e6-7890-ab12-cd34ef56gh10
                     CustomerId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh10",
                     RestaurantId = 20,
                     DeliveryAddressId = 16,
                     // Courier 23 -> c1a2b3d4-e5f6-7890-ab12-cd34ef56gh23
                     CourierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh23",
                     OrderTime = DateTime.UtcNow,
                     Status = OrderStatus.DeliveryInProgress
                 }
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
