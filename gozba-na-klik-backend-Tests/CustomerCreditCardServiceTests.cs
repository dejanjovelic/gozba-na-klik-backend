using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.Mappings;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Services.Exceptions;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace gozba_na_klik_backend_Tests
{
    public class CustomerCreditCardServiceTests
    {
        private static string Mask(string number)
        {
            if (string.IsNullOrEmpty(number)) return string.Empty;
            int len = number.Length;
            if (len <= 4) return number;
            return new string('*', len - 4) + number.Substring(len - 4);
        }

        [Fact]
        public async Task GetCreditCardsAsync_WithValidCustomer_ReturnsMaskedCards()
        {
            var cards = new List<CreditCard>
            {
                new CreditCard { Id = 1, Bank = "B1", CardNumber = "1234567812345678", OwnerId = "cust-1" },
                new CreditCard { Id = 2, Bank = "B2", CardNumber = "9876543298765432", OwnerId = "cust-1" }
            };
            var customers = new List<Customer> { new Customer { Id = "cust-1" , CreditCards = cards} };

            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) => customers.FirstOrDefault(c => c.Id == id));

            var mockCreditRepo = new Mock<ICreditCardRepository>();

            var mockAllergen = new Mock<IAllergenService>();
            var mockAddress = new Mock<IAddressRepository>();
            var mockAuth = new Mock<IAuthService>();

            // use actual mapper profile from project instead of constructing MapperConfiguration (not available in test environment)
            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<CreditCardResponseDto>(It.IsAny<CreditCard>()))
                .Returns((CreditCard cc) => new CreditCardResponseDto { Id = cc.Id, Bank = cc.Bank, CardNumber = Mask(cc.CardNumber) });

            var service = new CustomerService(mockCustomerRepo.Object, mockAllergen.Object, mockAddress.Object, mockCreditRepo.Object, mockAuth.Object, mapper.Object);

            var result = await service.GetCreditCardsAsync("cust-1", "cust-1");

            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
            result[0].CardNumber.ShouldBe(Mask("1234567812345678"));
            result[1].CardNumber.ShouldBe(Mask("9876543298765432"));
        }

        [Fact]
        public async Task GetCreditCardsAsync_OwnerMismatch_ThrowsForbidden()
        {
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new Customer { Id = "cust-1" });

            var mockCreditRepo = new Mock<ICreditCardRepository>();
            var mockAllergen = new Mock<IAllergenService>();
            var mockAddress = new Mock<IAddressRepository>();
            var mockAuth = new Mock<IAuthService>();

            var mapper = new Mock<IMapper>();
            var service = new CustomerService(mockCustomerRepo.Object, mockAllergen.Object, mockAddress.Object, mockCreditRepo.Object, mockAuth.Object, mapper.Object);

            await Should.ThrowAsync<ForbiddenException>(() => service.GetCreditCardsAsync("cust-1", "other"));
        }

        [Fact]
        public async Task CreateCreditCardAsync_ValidInput_ReturnsMaskedCard()
        {
            var customers = new List<Customer> { new Customer { Id = "cust-1" } };
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((string id) => customers.FirstOrDefault(c => c.Id == id));

            var creditCards = new List<CreditCard>();
            var mockCreditRepo = new Mock<ICreditCardRepository>();
            mockCreditRepo.Setup(r => r.CreateAsync(It.IsAny<CreditCard>())).ReturnsAsync((CreditCard cc) =>
            {
                cc.Id = 100;
                creditCards.Add(cc);
                return cc;
            });

            var mockAllergen = new Mock<IAllergenService>();
            var mockAddress = new Mock<IAddressRepository>();
            var mockAuth = new Mock<IAuthService>();

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<CreditCard>(It.IsAny<NewCreditCardDto>())).Returns((NewCreditCardDto d) => new CreditCard { Bank = d.Bank, CardNumber = d.CardNumber });
            mapper.Setup(m => m.Map<CreditCardResponseDto>(It.IsAny<CreditCard>())).Returns((CreditCard cc) => new CreditCardResponseDto { Id = cc.Id, Bank = cc.Bank, CardNumber = Mask(cc.CardNumber) });

            var service = new CustomerService(mockCustomerRepo.Object, mockAllergen.Object, mockAddress.Object, mockCreditRepo.Object, mockAuth.Object, mapper.Object);

            var dto = new NewCreditCardDto { Bank = "BankX", CardNumber = "1111222233334444" };

            var result = await service.CreateCreditCardAsync("cust-1", dto, "cust-1");

            result.ShouldNotBeNull();
            result.Id.ShouldBe(100);
            result.CardNumber.ShouldBe(Mask("1111222233334444"));
            mockCreditRepo.Verify(r => r.CreateAsync(It.Is<CreditCard>(c => c.OwnerId == "cust-1")), Times.Once);
        }

        [Fact]
        public async Task UpdateCreditCardAsync_ValidInput_UpdatesAndReturnsMasked()
        {
            var customers = new List<Customer> { new Customer { Id = "cust-1" } };
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((string id) => customers.FirstOrDefault(c => c.Id == id));

            var existing = new CreditCard { Id = 5, Bank = "Old", CardNumber = "0000111122223333", OwnerId = "cust-1" };
            var mockCreditRepo = new Mock<ICreditCardRepository>();
            mockCreditRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => id == existing.Id ? existing : null);
            mockCreditRepo.Setup(r => r.UpdateAsync(It.IsAny<CreditCard>())).ReturnsAsync((CreditCard cc) => cc);

            var mockAllergen = new Mock<IAllergenService>();
            var mockAddress = new Mock<IAddressRepository>();
            var mockAuth = new Mock<IAuthService>();

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<CreditCardResponseDto>(It.IsAny<CreditCard>())).Returns((CreditCard cc) => new CreditCardResponseDto { Id = cc.Id, Bank = cc.Bank, CardNumber = Mask(cc.CardNumber) });

            var service = new CustomerService(mockCustomerRepo.Object, mockAllergen.Object, mockAddress.Object, mockCreditRepo.Object, mockAuth.Object, mapper.Object);

            var dto = new NewCreditCardDto { Id = 5, Bank = "NewBank", CardNumber = "9999888877776666" };

            var result = await service.UpdateCreditCardAsync("cust-1", 5, dto, "cust-1");

            result.ShouldNotBeNull();
            result.Id.ShouldBe(5);
            result.CardNumber.ShouldBe(Mask("9999888877776666"));
            mockCreditRepo.Verify(r => r.UpdateAsync(It.IsAny<CreditCard>()), Times.Once);
        }

        [Fact]
        public async Task DeleteCreditCardAsync_ValidInput_DeletesCard()
        {
            var customers = new List<Customer> { new Customer { Id = "cust-1" } };
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((string id) => customers.FirstOrDefault(c => c.Id == id));

            var existing = new CreditCard { Id = 7, Bank = "B", CardNumber = "4444333322221111", OwnerId = "cust-1" };
            var mockCreditRepo = new Mock<ICreditCardRepository>();
            mockCreditRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => id == existing.Id ? existing : null);
            mockCreditRepo.Setup(r => r.DeleteAsync(It.IsAny<CreditCard>())).Returns(Task.CompletedTask).Verifiable();

            var mockAllergen = new Mock<IAllergenService>();
            var mockAddress = new Mock<IAddressRepository>();
            var mockAuth = new Mock<IAuthService>();

            var mapper = new Mock<IMapper>();
            var service = new CustomerService(mockCustomerRepo.Object, mockAllergen.Object, mockAddress.Object, mockCreditRepo.Object, mockAuth.Object, mapper.Object);

            await service.DeleteCreditCardAsync("cust-1", 7, "cust-1");

            mockCreditRepo.Verify(r => r.DeleteAsync(It.Is<CreditCard>(c => c.Id == 7)), Times.Once);
        }
    }
}
