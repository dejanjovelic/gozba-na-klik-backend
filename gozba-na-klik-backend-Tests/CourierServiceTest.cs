using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gozba_na_klik_backend_Tests
{
    public class CourierServiceTest
    {
        [Fact]
        public async Task GetByIdAsync_ExistingId_ReturnsCourier()
        {
            // Arrange
            var stubRepository = createRepository();
            var authService = new Mock<IAuthService>();
            var mapper = new Mock<IMapper>();
            var userManager = new Mock<UserManager<ApplicationUser>>();

            var service = new CourierService(stubRepository, authService.Object, mapper.Object, userManager.Object);

            // Act
            var courier = await service.GetByIdAsync("c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14", "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14");

            // Assert
            courier.ShouldNotBeNull();
            courier!.Name.ShouldBe("Jessica");
            courier.Username.ShouldBe("courier14");
        }

        [Fact]
        public async Task CreateAsync_ValidRegistration_ReturnsAuthTokenAndCreatesCourier()
        {
            // Arrange
            var mockCourierRepository = new Mock<ICourierRepository>();
            var mockAuthService = new Mock<IAuthService>();
            var mapper = new Mock<IMapper>();
            var userManager = new Mock<UserManager<ApplicationUser>>();


            var registrationDto = new RegistrationDto
            {
                Name = "New",
                Surname = "Courier",
                Email = "new.courier@example.com",
                UserName = "courier16",
                Password = "SecurePassword123!",
                PhoneNumber = "+381621234567"
            };

            const string expectedUserId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh16";
            NewCourierDto expectedToken = new NewCourierDto
            {
                Name = "New",
                Surname = "Courier",
                Email = "new.courier@example.com",
                UserName = "courier16",
                PhoneNumber = "+381621234567",
                Role = "Courier"
            };

            mockAuthService.Setup(s => s.RegisterUserAsync(registrationDto, "Courier"))
                           .ReturnsAsync(new AuthResponseDto
                           {
                               AplicationUserId = expectedUserId,
                               Token = "expectedtoken"
                           });

            Courier createdCourier = null;
            mockCourierRepository.Setup(r => r.CreateAsync(It.IsAny<Courier>()))
                                 .Callback<Courier>(courier => createdCourier = courier)
                                 .ReturnsAsync(new Courier { Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh16" });

            var service = new CourierService(mockCourierRepository.Object, mockAuthService.Object, mapper.Object, userManager.Object);

            // Act
            var actualToken = await service.CreateAsync(registrationDto);

            actualToken.ShouldSatisfyAllConditions(
                () => actualToken.Name.ShouldBe(expectedToken.Name),
                () => actualToken.Email.ShouldBe(expectedToken.Email),
                () => actualToken.UserName.ShouldBe(expectedToken.UserName)
                );
            createdCourier.Id.ShouldBe(expectedUserId);
            mockAuthService.Verify(s => s.RegisterUserAsync(registrationDto, "Courier"), Times.Once);
            mockCourierRepository.Verify(r => r.CreateAsync(It.IsAny<Courier>()), Times.Once);
        }


        [Fact]
        public async Task UpdateWorkingHoursAsync_ValidCourier_CallsRepository()
        {
            // Arrange
            var mockRepo = new Mock<ICourierRepository>();
            var authService = new Mock<IAuthService>();
            var mapper = new Mock<IMapper>();
            var userManager = new Mock<UserManager<ApplicationUser>>();

            var service = new CourierService(mockRepo.Object, authService.Object, mapper.Object, userManager.Object);


            var courierId = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14";
            var workingHours = new List<WorkingHours>
    {
        new WorkingHours
        {
            DayOfTheWeek = DayOfWeek.Monday,
            StartingTime = TimeSpan.FromHours(9),
            EndingTime = TimeSpan.FromHours(16)
        }
    };

            mockRepo.Setup(r => r.GetByIdAsync(courierId))
                    .ReturnsAsync(new Courier { Id = courierId, ApplicationUser = new ApplicationUser { Name = "Jessica" } });

            mockRepo.Setup(r => r.UpdateWorkingHoursAsync(It.IsAny<Courier>(), It.IsAny<List<WorkingHours>>()))
                    .Returns(Task.CompletedTask);

            // Act
            await service.UpdateWorkingHoursAsync(courierId, workingHours, courierId);

            // Assert
            mockRepo.Verify(
                r => r.UpdateWorkingHoursAsync(
                    It.Is<Courier>(c => c.Id == courierId),
                    workingHours),
                Times.Once
            );
        }

        private static ICourierRepository createRepository()
        {
            var _Couriers = new List<Courier>
            {
                 new Courier{
                    Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14",
                    ApplicationUser = new ApplicationUser
                    {
                        Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh14",
                        Name = "Jessica",
                        Surname = "Nguyen",
                        Email = "jameswells@example.net",
                        UserName = "courier14",
                        ProfileImageUrl = "https://example.com/courier14.png",
                        PhoneNumber = "+381621234567"
                    }
                 },
                 new Courier{
                     Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15",
                    ApplicationUser = new ApplicationUser
                    {
                        Id = "c1a2b3d4-e5f6-7890-ab12-cd34ef56gh15",
                        Name = "Samantha",
                        Surname = "Jackson",
                        Email = "turneremily@example.net",
                        UserName = "courier15",
                        ProfileImageUrl = "https://example.com/courier15.png",
                        PhoneNumber = "+381631118889"
                    }
                 }
            };

            var stubRepository = new Mock<ICourierRepository>();
            stubRepository.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                   .ReturnsAsync((string id) => _Couriers.FirstOrDefault(courier => courier.Id == id));

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
