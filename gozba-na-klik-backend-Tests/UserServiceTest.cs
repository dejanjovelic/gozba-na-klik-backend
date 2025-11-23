//using gozba_na_klik_backend.DTOs;
//using gozba_na_klik_backend.Model;
//using gozba_na_klik_backend.Model.IRepositories;
//using gozba_na_klik_backend.Services;
//using gozba_na_klik_backend.Services;
//using gozba_na_klik_backend.Services.IServices;
//using Microsoft.AspNetCore.Identity;
//using Moq;
//using Shouldly;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace gozba_na_klik_backend_Tests
//{
//    public static class MockingHelper
//    {
//        // Mock-ovanje UserManager-a je kompleksno jer mu je potreban IUserStore.
//        public static Mock<UserManager<TUser>> GetMockUserManager<TUser>(List<TUser> userList) where TUser : class
//        {
//            // 1. Pripremite podatke kao IQueryable (neophodno za Users.ToListAsync())
//            var queryableUsers = userList.AsQueryable();

//            // 2. Kreirajte Mock za UserStore
//            var mockUserStore = new Mock<IUserStore<TUser>>();

//            // 3. Kreirajte Mock za UserManager sa fiktivnim zavisnostima
//            var mockUserManager = new Mock<UserManager<TUser>>(
//                mockUserStore.Object, null, null, null, null, null, null, null, null);

//            // 4. Mock-ujte svojstvo Users da vraća listu kao IQueryable
//            mockUserManager.Setup(m => m.Users)
//                           .Returns(queryableUsers);

//            // 5. Mock-ujte FindByNameAsync (potreban za GetByUsernameAsync)
//            mockUserManager.Setup(m => m.FindByNameAsync(It.IsAny<string>()))
//                           .ReturnsAsync((string username) =>
//                               userList.FirstOrDefault(u => (u as ApplicationUser)?.UserName == username));

//            return mockUserManager;
//        }
//    }
//    public class UserServiceTest
//    {
//        [Fact]
//        public async Task GetByUsernameAsync_ShouldReturnUserThatMatchesTheUsername()
//        {
//            // Arrange
//            var stubRepository = createRepository();
//            var service = new UserService(stubRepository);

//            // Act
//            var user = await service.GetByUsernameAsync("customer4");

//            // Assert
//            user.ShouldNotBeNull();
//            user!.Name.ShouldBe("Ashley");
//            user.Username.ShouldBe("customer4");
//        }
//        [Fact]
//        public async Task GetAllAsync_ShouldReturnAllUsers()
//        {
//            // Arrange
//            var stubRepository = createRepository();
//            var Service = new UserService(stubRepository);
//            //Act
//            List<ApplicationUser> Users = await Service.GetAllAsync();
//            //Assert
//            Users.Count.ShouldBe(8);
//        }
//        private static IUserRepository createRepository()
//        {
//            var _users = new List<ApplicationUser>
//            {


//                  = new ApplicationUser
//                  {
//                      Id = "a1f2c3d4-e5f6-7890-ab12-cd34ef56gh78",
//                      Name = "Ashley",
//                      Surname = "Diaz",
//                      Email = "walkerlaura@example.net",
//                      UserName = "admin1",
//                      ProfileImageUrl = "https://example.com/admin1.png",
//                      PhoneNumber = "+381601112223"

//                  }





//                admin2 = new ApplicationUser
//                {
//                    Id = "b2e3f4g5-h6i7-8901-bc23-de45fg67hi89",
//                    Name = "Michelle",
//                    Surname = "Nguyen",
//                    Email = "davidmullins@example.org",
//                    UserName = "admin2",
//                    ProfileImageUrl = "https://example.com/admin2.png",
//                    PhoneNumber = "+381611234567"
//                };
//                await userManager.CreateAsync(admin2, "Admin@123");



//            if (!await userManager.IsInRoleAsync(admin2, "Administrator"))
//            {
//                await userManager.AddToRoleAsync(admin2, "Administrator");
//            }

//            // Customers
//            new Customer
//            {
//                ApplicationUserId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02",
//                ApplicationUser = new ApplicationUser
//                {
//                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02",
//                    Name = "Emily",
//                    Surname = "Austin",
//                    Email = "reynoldscourtney@example.net",
//                    UserName = "customer5",
//                    ProfileImageUrl = "https://example.com/customer5.png",
//                    PhoneNumber = "+381631234567",
//                    DateOfBirth = new DateTime(2000, 1, 25, 0, 0, 0, DateTimeKind.Utc)
//                }

//            };
//            new Customer
//            {
//                ApplicationUserId = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01",
//                ApplicationUser = new ApplicationUser
//                {
//                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01",
//                    Name = "Ashley",
//                    Surname = "Green",
//                    Email = "caseymaria@example.com",
//                    UserName = "customer4",
//                    ProfileImageUrl = "https://example.com/customer4.png",
//                    PhoneNumber = "+381621112223",
//                    DateOfBirth = new DateTime(1995, 5, 10, 0, 0, 0, DateTimeKind.Utc)
//                },
//            };


//            // Couriers
//            new Courier
//            {
//                ApplicationUserId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14",
//                ApplicationUser = new ApplicationUser
//                {
//                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14",
//                    Name = "Jessica",
//                    Surname = "Nguyen",
//                    Email = "jameswells@example.net",
//                    UserName = "courier14",
//                    ProfileImageUrl = "https://example.com/courier14.png",
//                    PhoneNumber = "+381621234567"
//                }
//            };
//            new Courier
//            {
//                ApplicationUserId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15",
//                ApplicationUser = new ApplicationUser
//                {
//                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15",
//                    Name = "Samantha",
//                    Surname = "Jackson",
//                    Email = "turneremily@example.net",
//                    UserName = "courier15",
//                    ProfileImageUrl = "https://example.com/courier15.png",
//                    PhoneNumber = "+381631118889"
//                }
//            };

//            // Restaurant Owners
//            new RestaurantOwner
//            {
//                ApplicationUserId = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24",
//                ApplicationUser = new ApplicationUser
//                {
//                    Id = "r1a2b3c4-d5e6-7890-ab12-cd34ef56gh24",
//                    Name = "Victor",
//                    Surname = "Diaz",
//                    Email = "victor.diaz@example.com",
//                    UserName = "owner24",
//                    ProfileImageUrl = "https://example.com/owner24.png",
//                    PhoneNumber = "+381621111234"
//                }
//            };

//            // Employees
//            new Employee
//            {
//                ApplicationUserId = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh34",
//                ApplicationUser = new ApplicationUser
//                {
//                    Id = "e1a2b3c4-d5e6-7890-ab12-cd34ef56gh34",
//                    Name = "Noah",
//                    Surname = "Walker",
//                    Email = "noah.walker@example.com",
//                    UserName = "employee34",
//                    ProfileImageUrl = "https://example.com/employee34.png",
//                    PhoneNumber = "+381621112777"
//                }
//            };
//        };
//        var stubRepository = new Mock<IUserRepository>();
//        stubRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(_users);
//        stubRepository.Setup(r => r.GetByUsernameAsync(It.IsAny<string>()))
//                          .ReturnsAsync((string username) => _users.FirstOrDefault(u => u.Username == username));
//            return stubRepository.Object;
//        }
//}
//}
