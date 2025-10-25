
using Castle.Core.Resource;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services;
using gozba_na_klik_backend.Services.IServices;
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

        public static IEnumerable<object[]> AllergenIdData =>
        new List<object[]>
        {
            new object[]{ new List<int> {1,2,3,4} }
        };


        [Theory]
        [MemberData(nameof(AllergenIdData))]
        public async Task GetAllSelectedAllergensAsync_ShouldThrowBadRequestException_WhenAllergenIdDoesNotExist(List<int> allergenIds)
        {
            var stubRepository = createRepository();
            var service = new AllergenService(stubRepository);


            var result = await service.GetAllSelectedAllergensAsync(allergenIds);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(allergenIds.Count);
            result.ShouldContain(result.FirstOrDefault(allergen=>allergen.Id==1));
            result.ShouldContain(result.FirstOrDefault(allergen => allergen.Name.ToLower() == "oats"));
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

            stubRepository
                .Setup(r => r.GetAllSelectedAllergensAsync(It.IsAny<List<int>>()))
                .ReturnsAsync((List<int> allergenIds) => allergens.Where(allergen => allergenIds.Contains(allergen.Id)).ToList());

            return stubRepository.Object;
        }
    }
}