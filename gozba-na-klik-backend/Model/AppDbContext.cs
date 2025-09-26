using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
<<<<<<< HEAD
=======

>>>>>>> master
        }
    }
}
