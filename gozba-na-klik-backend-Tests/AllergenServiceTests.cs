
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Servises;
using gozba_na_klik_backend.Servises.IServices;
using Moq;
using Shouldly;

namespace gozba_na_klik_backend_Tests
{
    public class AllergenServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllAllergens_WhenRepositoryIsPopulated()
        {
            var stubRepository = createRepository();
            var service = new AllergenService(stubRepository);

            var result = await service.GetAllAsync();

            result.ShouldNotBeNull();
            result.Count.ShouldBe(6);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenRepositoryReturnsNoAllergens()
        {
            var stubRepository = new Mock<IAllergenRepository>();
            stubRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Allergen>());

            var service = new AllergenService(stubRepository.Object);

            var result = await service.GetAllAsync();

            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }


        private static IAllergenRepository createRepository()
        {
            List<Allergen> allergens = new List<Allergen>
            {
                new Allergen { Id = 1, Name = "wheat" },
                new Allergen { Id = 2, Name = "rye" },
                new Allergen { Id = 3, Name = "barley" },
                new Allergen { Id = 4, Name = "oats" },
                new Allergen { Id = 5, Name = "crabs" },
                new Allergen { Id = 6, Name = "lobsters" }
            };

            var stubRepository = new Mock<IAllergenRepository>();
            stubRepository.Setup(a => a.GetAllAsync()).ReturnsAsync(allergens);
            return stubRepository.Object;
        }
    }
}