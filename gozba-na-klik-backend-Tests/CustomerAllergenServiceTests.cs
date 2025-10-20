using Castle.Core.Resource;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Servises;
using gozba_na_klik_backend.Servises.IServices;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gozba_na_klik_backend_Tests
{
    public class CustomerAllergenServiceTests
    {
        [Theory]
        [InlineData(1)]
        public async Task GettingCustomerAllergens_throwsNotFoundException_whenCustomerDoesNotExist(int id)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();

            var servise = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object);

            var ex = await Assert.ThrowsAsync<NotFoundException>(() => servise.GetAllCustomerAllergensAsync(id));
            ex.Message.ShouldContain($"Customer with ID: {id} not found.");
        }

        [Theory]
        [InlineData(4)]
        public async Task GetAllCustomerAllergensAsync_ShouldReturnAllergens_WhenCustomerExists(int id)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();

            var service = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object);

            var result = await service.GetAllCustomerAllergensAsync(id);
            result.ShouldNotBeNull();
            result.Count.ShouldBe(3);
            result.ShouldContain(allergen => allergen.Name == "prawns");
        }

        [Theory]
        [InlineData(7)]
        public async Task GetAllCustomerAllergensAsync_ShouldReturnEmptyList_WhenCustomerHasNoAllergens(int id)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();
            var service = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object);

            var result = await service.GetAllCustomerAllergensAsync(id);

            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        public static IEnumerable<object[]> CustomerWithData =>
        new List<object[]>
        {
            new object[]{3, new List<int> {1,2,3 } }
        };

        [Theory]
        [MemberData(nameof(CustomerWithData))]
        public async Task UpdateCustomerAllergensAsync_ShouldThrowNotFoundException_WhenCustomerDoesNotExist(int customerId, List<int> allergenIds)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();

            var service = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object);

            await Assert.ThrowsAsync<NotFoundException>(() => service.UpdateCustomerAllergensAsync(customerId, allergenIds));
        }

        public static IEnumerable<object[]> CustomerWithNotExistingAllergenIDData =>
           new List<object[]>
           {
                new object[]{6, new List<int> {1,2,38} }
           };

        [Theory]
        [MemberData(nameof(CustomerWithNotExistingAllergenIDData))]
        public async Task UpdateCustomerAllergensAsync_ShouldReturnListOfAllergen_WhenAllAllergensFromListExist(int customerId, List<int> allergenIds)
        {
            var stubRepository = createRepository();
            var allergenMockService = new Mock<IAllergenService>();
            var addressMockRepo = new Mock<IAddressRepository>();
            allergenMockService
           .Setup(allergenService => allergenService.GetAllSelectedAllergensAsync(It.IsAny<List<int>>()))
           .ReturnsAsync((List<int> allergenIds) => allergenIds
           .Select(id => new Allergen { Id = id, Name = $"Allergen{id}" })
           .ToList());

            var service = new CustomerService(stubRepository, allergenMockService.Object, addressMockRepo.Object);

            Customer result = await service.UpdateCustomerAllergensAsync(customerId, allergenIds);

           
            result.ShouldNotBeNull();
            result.Allergens.ShouldNotBeNull();
            result.Allergens.Count.ShouldBe(3);
        }


        public static ICustomerRepository createRepository()
        {
            List<Customer> customers = new List<Customer>
            {
                 new Customer {
                     Id = 4,
                     Name = "Ashley",
                     Surname = "Green",
                     Email = "caseymaria@example.com",
                     Username = "customer4",
                     Password = "cust123",
                     ProfileImageUrl = "https://example.com/customer4.png",
                     ContactNumber = "+381621112223",
                     Allergens = new List<Allergen>
                    {
                        new Allergen { Id = 7, Name = "prawns" },
                        new Allergen { Id = 8, Name = "eggs" },
                        new Allergen { Id = 9, Name = "fish" }
                    }

                 },
                new Customer {
                    Id = 5,
                    Name = "Emily",
                    Surname = "Austin",
                    Email = "reynoldscourtney@example.net",
                    Username = "customer5",
                    Password = "cust123",
                    ProfileImageUrl = "https://example.com/customer5.png",
                    ContactNumber = "+381631234567",
                    Allergens = new List<Allergen>
                    {
                        new Allergen { Id = 1, Name = "wheat" },
                        new Allergen { Id = 2, Name = "rye" },
                        new Allergen { Id = 3, Name = "barley" }
                    }
                },
                new Customer {
                    Id = 6,
                    Name = "Wendy",
                    Surname = "Vargas",
                    Email = "michael99@example.org",
                    Username = "customer6",
                    Password = "cust123",
                    ProfileImageUrl = "https://example.com/customer6.png",
                    ContactNumber = "+381601234321",
                    Allergens = new List<Allergen>
                    {
                        new Allergen { Id = 4, Name = "oats" },
                        new Allergen { Id = 5, Name = "crabs" },
                        new Allergen { Id = 6, Name = "lobsters" }
                    }
                },
                new Customer {
                     Id = 7,
                     Name = "Kimberly",
                     Surname = "Brown",
                     Email = "robertschristopher@example.net",
                     Username = "customer7", Password = "cust123",
                     ProfileImageUrl = "https://example.com/customer7.png",
                     ContactNumber = "+381641112233",
                     Allergens = new List<Allergen>()
                },
                new Customer {
                     Id = 8,
                     Name = "David",
                     Surname = "Sims",
                     Email = "nelsonrebecca@example.com",
                     Username = "customer8",
                     Password = "cust123",
                     ProfileImageUrl = "https://example.com/customer8.png",
                     ContactNumber = "+381611231231",
                     Allergens = null
                }
            };

            var stubRepository = new Mock<ICustomerRepository>();

            stubRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => customers.FirstOrDefault(customer => customer.Id == id));
            
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
