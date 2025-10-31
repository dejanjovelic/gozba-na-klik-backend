using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Services;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gozba_na_klik_backend.DTOs;

namespace gozba_na_klik_backend_Tests
{
    public class UserServiceTest
    {
        [Fact]
        public async Task GetByUsernameAsync_ShouldReturnUserThatMatchesTheUsername()
        {
            // Arrange
            var stubRepository = createRepository();
            var service = new UserService(stubRepository);

            // Act
            var user = await service.GetByUsernameAsync("customer4");

            // Assert
            user.ShouldNotBeNull();
            user!.Name.ShouldBe("Ashley");
            user.Username.ShouldBe("customer4");
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllUsers()
        {
            // Arrange
            var stubRepository = createRepository();
            var Service = new UserService(stubRepository);
            //Act
            List<User>Users= await Service.GetAllAsync();
            //Assert
            Users.Count.ShouldBe(8);
        }
        private static IUserRepository createRepository()
        {
           var _users = new List<User>
        {
            // Administrators
            new Administrator { Id = 1, Name = "Ashley", Surname = "Diaz", Username = "admin1", Password = "admin123", Email = "walkerlaura@example.net", ProfileImageUrl = "https://example.com/admin1.png", ContactNumber = "+381601112223" },
            new Administrator { Id = 2, Name = "Michelle", Surname = "Nguyen", Username = "admin2", Password = "admin123", Email = "davidmullins@example.org", ProfileImageUrl = "https://example.com/admin2.png", ContactNumber = "+381611234567" },

            // Customers
            new Customer { Id = 4, Name = "Ashley", Surname = "Green", Username = "customer4", Password = "cust123", Email = "caseymaria@example.com", ProfileImageUrl = "https://example.com/customer4.png", ContactNumber = "+381621112223" },
            new Customer { Id = 5, Name = "Emily", Surname = "Austin", Username = "customer5", Password = "cust123", Email = "reynoldscourtney@example.net", ProfileImageUrl = "https://example.com/customer5.png", ContactNumber = "+381631234567" },

            // Couriers
            new Courier { Id = 14, Name = "Jessica", Surname = "Nguyen", Username = "courier14", Password = "courier123", Email = "jameswells@example.net", ProfileImageUrl = "https://example.com/courier14.png", ContactNumber = "+381621234567" },
            new Courier { Id = 15, Name = "Samantha", Surname = "Jackson", Username = "courier15", Password = "courier123", Email = "turneremily@example.net", ProfileImageUrl = "https://example.com/courier15.png", ContactNumber = "+381631118889" },

            // Restaurant Owners
            new RestaurantOwner { Id = 24, Name = "Victor", Surname = "Diaz", Username = "owner24", Password = "owner123", Email = "victor.diaz@example.com", ProfileImageUrl = "https://example.com/owner24.png", ContactNumber = "+381621111234" },

            // Employees
            new Employee { Id = 34, Name = "Noah", Surname = "Walker", Username = "employee34", Password = "emp123", Email = "noah.walker@example.com", ProfileImageUrl = "https://example.com/employee34.png", ContactNumber = "+381621112777" }
        };
            var stubRepository = new Mock<IUserRepository>();
            stubRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(_users);
            stubRepository.Setup(r => r.GetByUsernameAsync(It.IsAny<string>()))
                          .ReturnsAsync((string username) => _users.FirstOrDefault(u => u.Username == username));
            return stubRepository.Object;
        }
    }
}
