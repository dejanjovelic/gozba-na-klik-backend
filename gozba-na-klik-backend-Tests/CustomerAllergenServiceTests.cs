using Castle.Core.Resource;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services;
using gozba_na_klik_backend.Services.IServices;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace gozba_na_klik_backend_Tests
{
    public class CustomerAllergenServiceTests
    {
        [Theory]
        [InlineData("f1a2b3c4-d5e6-7890-ab12-cd34ef56gh00")]
        public async Task GettingCustomerAllergens_throwsNotFoundException_whenCustomerDoesNotExist(string id)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();
            var authService = new Mock<IAuthService>();

            var servise = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object, authService.Object);

            var ex = await Assert.ThrowsAsync<NotFoundException>(() => servise.GetAllCustomerAllergensAsync(id));
            ex.Message.ShouldContain($"Customer with ID: {id} not found.");
        }

        [Theory]
        [InlineData("f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01")]
        public async Task GetAllCustomerAllergensAsync_ShouldReturnAllergens_WhenCustomerExists(string id)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();
            var authService = new Mock<IAuthService>();

            var service = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object, authService.Object);

            var result = await service.GetAllCustomerAllergensAsync(id);
            result.ShouldNotBeNull();
            result.Count.ShouldBe(3);
            result.ShouldContain(allergen => allergen.Name == "prawns");
        }

        [Theory]
        [InlineData("f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03")]
        public async Task GetAllCustomerAllergensAsync_ShouldReturnEmptyList_WhenCustomerHasNoAllergens(string id)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();
            var authService = new Mock<IAuthService>();
            var service = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object, authService.Object);

            var result = await service.GetAllCustomerAllergensAsync(id);

            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        public static IEnumerable<object[]> CustomerWithData =>
        new List<object[]>
        {
            new object[]{ "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh00", new List<int> { 1, 2, 3 } }
        };

        [Theory]
        [MemberData(nameof(CustomerWithData))]
        public async Task UpdateCustomerAllergensAsync_ShouldThrowNotFoundException_WhenCustomerDoesNotExist(string customerId, List<int> allergenIds)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();
            var authService = new Mock<IAuthService>();

            var service = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object, authService.Object);

            await Assert.ThrowsAsync<NotFoundException>(() => service.UpdateCustomerAllergensAsync(customerId, allergenIds));
        }

        public static IEnumerable<object[]> CustomerWithNotExistingAllergenIDData =>
           new List<object[]>
           {
                new object[]{ "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01", new List<int> {1,2,38} }
           };

        [Theory]
        [MemberData(nameof(CustomerWithNotExistingAllergenIDData))]
        public async Task UpdateCustomerAllergensAsync_ShouldReturnListOfAllergen_WhenAllAllergensFromListExist(string customerId, List<int> allergenIds)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();
            var authService = new Mock<IAuthService>();
            allergenMockService
           .Setup(allergenService => allergenService.GetAllSelectedAllergensAsync(It.IsAny<List<int>>()))
           .ReturnsAsync((List<int> allergenIds) => allergenIds
           .Select(id => new Allergen { Id = id, Name = $"Allergen{id}" })
           .ToList());

            var service = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object, authService.Object);

            Customer result = await service.UpdateCustomerAllergensAsync(customerId, allergenIds);

           
            result.ShouldNotBeNull();
            result.Allergens.ShouldNotBeNull();
            result.Allergens.Count.ShouldBe(3);
        }


        public static ICustomerRepository createRepository()
        {
            List<Customer> customers = new List<Customer>
            {
                 new Customer{
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02",
                    ApplicationUser = new ApplicationUser
                    {
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02",
                            Name = "Emily",
                            Surname = "Austin",
                            Email = "reynoldscourtney@example.net",
                            UserName = "customer5",
                            ProfileImageUrl = "https://example.com/customer5.png",
                            PhoneNumber = "+381631234567",
                            DateOfBirth = new DateTime(2000, 1, 25, 0, 0, 0, DateTimeKind.Utc)
                    },
                     Allergens = new List<Allergen>
                    {
                        new Allergen { Id = 1, Name = "wheat" },
                        new Allergen { Id = 2, Name = "rye" },
                        new Allergen { Id = 3, Name = "barley" }
                    }

                 },
                 new Customer{
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01",
                    ApplicationUser = new ApplicationUser
                    {
                        Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh01",
                        Name = "Ashley",
                        Surname = "Green",
                        Email = "caseymaria@example.com",
                        UserName = "customer4",
                        ProfileImageUrl = "https://example.com/customer4.png",
                        PhoneNumber = "+381621112223",
                        DateOfBirth = new DateTime(1995, 5, 10, 0, 0, 0, DateTimeKind.Utc)
                    },
                    Allergens = new List<Allergen>
                    {
                        new Allergen { Id = 7, Name = "prawns" },
                        new Allergen { Id = 8, Name = "eggs" },
                        new Allergen { Id = 9, Name = "fish" }
                    }

                 },
                 new Customer{
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02",
                    ApplicationUser = new ApplicationUser
                    {
                        Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh02",
                        Name = "Emily",
                        Surname = "Austin",
                        Email = "reynoldscourtney@example.net",
                        UserName = "customer5",
                        ProfileImageUrl = "https://example.com/customer5.png",
                        PhoneNumber = "+381631234567",
                        DateOfBirth = new DateTime(2000, 1, 25, 0, 0, 0, DateTimeKind.Utc)
                    },
                    Allergens = new List<Allergen>
                    {
                        new Allergen { Id = 4, Name = "oats" },
                        new Allergen { Id = 5, Name = "crabs" },
                        new Allergen { Id = 6, Name = "lobsters" }
                    }

                 },
                 new Customer{
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03",
                    ApplicationUser = new ApplicationUser
                    {
                        Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh03",
                        Name = "Wendy",
                        Surname = "Vargas",
                        Email = "michael99@example.org",
                        UserName = "customer6",
                        ProfileImageUrl = "https://example.com/customer6.png",
                        PhoneNumber = "+381601234321",
                        DateOfBirth = new DateTime(1988, 12, 3, 0, 0, 0, DateTimeKind.Utc)
                    },
                    Allergens = new List<Allergen>()

                 },
                 new Customer{
                    Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04",
                    ApplicationUser = new ApplicationUser
                    {
                        Id = "f1a2b3c4-d5e6-7890-ab12-cd34ef56gh04",
                        Name = "Kimberly",
                        Surname = "Brown",
                        Email = "robertschristopher@example.net",
                        UserName = "customer7",
                        ProfileImageUrl = "https://example.com/customer7.png",
                        PhoneNumber = "+381641112233",
                        DateOfBirth = new DateTime(1991, 7, 18, 0, 0, 0, DateTimeKind.Utc)
                    },
                     Allergens = null

                 },
            };
                

            var stubRepository = new Mock<ICustomerRepository>();

            stubRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) => customers.FirstOrDefault(customer => customer.Id == id));
            
            stubRepository
                .Setup(repo => repo.UpdateCustomerAllergensAsync(It.IsAny<Customer>(), It.IsAny<List<Allergen>>()))
            .ReturnsAsync((Customer c, List<Allergen> allergens) =>
            {
                c.Allergens = allergens;
                return c;
            });

            return stubRepository.Object;

        }
    }
}
