using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services;
using gozba_na_klik_backend.Services.IServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace gozba_na_klik_backend_Tests
{
    public class CourierServiceTest
    {
        [Fact]
        public async Task GetByIdAsync_ExistingId_ReturnsCourier()
        {
            // Arrange
            var stubRepository = createRepository();
            var service = new CourierService(stubRepository);

            // Act
            var courier = await service.GetByIdAsync(1);

            // Assert
            courier.ShouldNotBeNull();
            courier!.Name.ShouldBe("Jessica");
            courier.Username.ShouldBe("courier14");
        }
        [Fact]
        public async Task CreateAsync_ValidCourier_ReturnsCreatedCourier()
        {
            //Arrange
            var stubRepository = createRepository();
            var service = new CourierService(stubRepository);
            var newCourier = new Courier
            {
                Id = 16,
                Name = "New",
                Surname = "Courier",
                Username = "courier16",
                Password = "pass123",
                Email = "new.courier@example.com"
            };

            // Act
            var created = await service.CreateAsync(newCourier);

            // Assert
            created.ShouldNotBeNull();
            created.Id.ShouldBe(16);
            created.Name.ShouldBe("New");
            created.Username.ShouldBe("courier16");
        }
        [Fact]
        public async Task UpdateWorkingHoursAsync_ValidCourier_CallsRepository()
        {
            // Arrange
            var mockRepo = new Mock<ICourierRepository>();
            var service = new CourierService(mockRepo.Object);

            var courier = new Courier { Id = 14, Name = "Jessica" };
            var workingHours = new List<WorkingHours>
            {
                new WorkingHours
                {
                    DayOfTheWeek = DayOfWeek.Monday,
                    StartingTime = TimeSpan.FromHours(9),  
                    EndingTime = TimeSpan.FromHours(16)    
                },
                new WorkingHours
                {
                    DayOfTheWeek = DayOfWeek.Tuesday,
                    StartingTime = TimeSpan.FromHours(10),
                    EndingTime = TimeSpan.FromHours(18)
                }
            };

            // Act
            await service.UpdateWorkingHoursAsync(courier, workingHours);

            // Assert
            mockRepo.Verify(r => r.UpdateWorkingHoursAsync(courier, workingHours), Times.Once);

        }
        
        private static ICourierRepository createRepository()
        {
            var _Couriers = new List<Courier>
            {
            new Courier { Id = 1, Name = "Jessica", Surname = "Nguyen", Username = "courier14", Password = "courier123", Email = "jameswells@example.net", ProfileImageUrl = "https://example.com/courier14.png", ContactNumber = "+381621234567" },
            new Courier { Id = 2, Name = "Samantha", Surname = "Jackson", Username = "courier15", Password = "courier123", Email = "turneremily@example.net", ProfileImageUrl = "https://example.com/courier15.png", ContactNumber = "+381631118889" },
            };
            var stubRepository = new Mock<ICourierRepository>();
            stubRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                   .ReturnsAsync((int id) => _Couriers.FirstOrDefault(courier => courier.Id == id));

            stubRepository.Setup(r => r.CreateAsync(It.IsAny<Courier>()))
                          .ReturnsAsync((Courier courier) =>
                          {
                              _Couriers.Add(courier);
                              return courier;
                          });

            stubRepository.Setup(repository => repository.UpdateWorkingHoursAsync(It.IsAny<Courier>(), It.IsAny<List<WorkingHours>>()))
                          .Returns(Task.CompletedTask);

            return stubRepository.Object;
        }
    }
}
