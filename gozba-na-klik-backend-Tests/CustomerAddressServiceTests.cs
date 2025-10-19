using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
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
    public class CustomerAddressServiceTests
    {
        [Fact]
        public async Task GetAddressesAsync_WithValidCustomerId_ReturnsAddresses()
        {
            CustomerService service = CreateCustomerService();

            var result = await service.GetAddressesAsync(4);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetAddressesAsync_NonExistingCustomer_ThrowsNotFoundException()
        {
            CustomerService service = CreateCustomerService();

            await Should.ThrowAsync<NotFoundException>(() => service.GetAddressesAsync(0));
        }

        [Fact]
        public async Task CreateAddressAsync_ValidInput_ShouldCreateAddress()
        {
            CustomerService service = CreateCustomerService();

            var newAddress = new Address
            {
                Street = "Test Street",
                StreetNumber = 99,
                City = "Test City",
                ZipCode = "12345"
            };

            var result = await service.CreateAddressAsync(5, newAddress);

            result.ShouldNotBeNull();
            result.Id.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateAddressAsync_NullAddress_ThrowsBadRequestException()
        {
            CustomerService service = CreateCustomerService();

            await Should.ThrowAsync<BadRequestException>(() => service.CreateAddressAsync(4, null));
        }

        [Fact]
        public async Task CreateAddressAsync_NonExistingCustomer_ThrowsNotFoundException()
        {
            CustomerService service = CreateCustomerService();

            var newAddress = new Address
            {
                Street = "Test Street",
                StreetNumber = 99,
                City = "Test City",
                ZipCode = "12345"
            };

            await Should.ThrowAsync<NotFoundException>(() => service.CreateAddressAsync(555, newAddress));
        }


        [Fact]
        public async Task UpdateAddressAsync_ValidData_ShouldUpdateAddress()
        {
            CustomerService service = CreateCustomerService();

            var updatedAddress = new Address
            {
                Id = 1,
                Street = "Updated Street",
                StreetNumber = 100,
                City = "Updated City",
                ZipCode = "99999"
            };

            var result = await service.UpdateAddressAsync(4, 1, updatedAddress);

            result.Street.ShouldBe("Updated Street");
            result.City.ShouldBe("Updated City");
        }

        [Fact]
        public async Task UpdateAddressAsync_MismatchedIds_ShouldThrowBadRequest()
        {
            CustomerService service = CreateCustomerService();

            var updatedAddress = new Address
            {
                Id = 3,
                Street = "Updated Street",
                StreetNumber = 100,
                City = "Updated City",
                ZipCode = "99999"
            };

            await Should.ThrowAsync<BadRequestException>(() => service.UpdateAddressAsync(4, 1, updatedAddress));
        }

        [Fact]
        public async Task UpdateAddressAsync_NonExistingCustomer_ThrowsNotFoundException()
        {
            CustomerService service = CreateCustomerService();

            var updatedAddress = new Address
            {
                Id = 1,
                Street = "Updated Street",
                StreetNumber = 100,
                City = "Updated City",
                ZipCode = "99999"
            };

            await Should.ThrowAsync<NotFoundException>(() => service.UpdateAddressAsync(555, 1, updatedAddress));
        }

        [Fact]
        public async Task UpdateAddressAsync_NonExistingAddress_ThrowsNotFoundException()
        {
            CustomerService service = CreateCustomerService();

            var updatedAddress = new Address
            {
                Id = 999,
                Street = "Updated Street",
                StreetNumber = 100,
                City = "Updated City",
                ZipCode = "99999"
            };

            await Should.ThrowAsync<NotFoundException>(() => service.UpdateAddressAsync(5, 999, updatedAddress));
        }

        [Fact]
        public async Task DeleteAddressAsync_ValidData_ShouldDeleteAddress()
        {
            CustomerService service = CreateCustomerService();

            await service.DeleteAddressAsync(4, 1);

            var addresses = await service.GetAddressesAsync(4);
            addresses.ShouldNotContain(a => a.Id == 1);
        }

        [Fact]
        public async Task DeleteAddressAsync_NonExistingAddress_ThrowsNotFoundException()
        {
            CustomerService service = CreateCustomerService();

            await Should.ThrowAsync<NotFoundException>(() => service.DeleteAddressAsync(4, 999));
        }

        [Fact]
        public async Task DeleteAddressAsync_NonExistingCustomer_ThrowsNotFound()
        {
            CustomerService service = CreateCustomerService();

            await Should.ThrowAsync<NotFoundException>(() => service.DeleteAddressAsync(555, 1));
        }

        private static CustomerService CreateCustomerService()
        {
            var (customerStubRepository, addressStubRepository) = CreateRepositories();
            var allergenRepo = new Mock<IAllergenRepository>();

            var service = new CustomerService(customerStubRepository, allergenRepo.Object, addressStubRepository);

            return service;
        }

        public static (ICustomerRepository, IAddressRepository) CreateRepositories()
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
                     ContactNumber = "+381621112223"
                 },
                new Customer {
                    Id = 5,
                    Name = "Emily",
                    Surname = "Austin",
                    Email = "reynoldscourtney@example.net",
                    Username = "customer5",
                    Password = "cust123",
                    ProfileImageUrl = "https://example.com/customer5.png",
                    ContactNumber = "+381631234567"
                }
            };

            var customerStubRepository = new Mock<ICustomerRepository>();

            customerStubRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => customers.FirstOrDefault(customer => customer.Id == id));
            
            List<Address> addresses = new List<Address>
            {
                new Address {
                    Id = 1,
                    Street = "Main Street",
                    StreetNumber = 12,
                    City = "Belgrade",
                    ZipCode = "11000",
                    CustomerId = 4
                },
                new Address {
                    Id = 2,
                    Street = "Green Avenue",
                    StreetNumber = 3,
                    City = "Novi Sad",
                    ZipCode = "21000",
                    CustomerId = 4
                },
                new Address {
                    Id = 3,
                    Street = "Sunset Blvd",
                    StreetNumber = 44,
                    City = "Niš",
                    ZipCode = "18000",
                    CustomerId = 5
                }
            };

            var addressStubRepository = new Mock<IAddressRepository>();

            addressStubRepository
                .Setup(repo => repo.GetByCustomerIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int customerId) => addresses.Where(a => a.CustomerId == customerId).ToList());

            addressStubRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => addresses.FirstOrDefault(a => a.Id == id));

            addressStubRepository
                .Setup(repo => repo.CreateAsync(It.IsAny<Address>()))
                .ReturnsAsync((Address addr) =>
                {
                    addr.Id = addresses.Max(a => a.Id) + 1;
                    addresses.Add(addr);
                    return addr;
                });

            addressStubRepository
                .Setup(repo => repo.UpdateAsync(It.IsAny<Address>()))
                .ReturnsAsync((Address addr) =>
                {
                    var index = addresses.FindIndex(a => a.Id == addr.Id);
                    if (index != -1)
                    {
                        addresses[index] = addr;
                        return addr;
                    }
                    return null;
                });

            addressStubRepository
                .Setup(repo => repo.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    var addr = addresses.FirstOrDefault(a => a.Id == id);
                    if (addr != null)
                    {
                        addresses.Remove(addr);
                        return true;
                    }
                    return false;
                });

            return (customerStubRepository.Object,  addressStubRepository.Object);
        }
    }
}
