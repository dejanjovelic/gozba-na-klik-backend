using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services;
using gozba_na_klik_backend_Tests.Helper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gozba_na_klik_backend_Tests
{
    public class RestaurantServiceTests
    {
        [Fact]
        public async Task GetAllFilteredAndSortedAndPagedAsync_Throws_Bad_Request_When_Page_Is_Less_Than_1()
        {
            var stubRepo = createRepositoy();
            var service = new RestaurantService(stubRepo);
            RestaurantFilterDto filterDto = new RestaurantFilterDto();
            int sortType = 0;
            int page = 0;
            int pageSize = 1;


            await Should.ThrowAsync<BadRequestException>(async () =>
            {
                await service.GetAllFilteredAndSortedAndPagedAsync(filterDto, sortType, page, pageSize);
            });
        }

        [Fact]
        public async Task GetAllFilteredAndSortedAndPagedAsync_Throws_Bad_Request_When_PageSize_Is_Less_Than_1()
        {
            var stubRepo = createRepositoy();
            var service = new RestaurantService(stubRepo);
            RestaurantFilterDto filterDto = new RestaurantFilterDto();
            int sortType = 0;
            int page = 1;
            int pageSize = 0;

            await Should.ThrowAsync<BadRequestException>(async () =>
            {
                await service.GetAllFilteredAndSortedAndPagedAsync(filterDto, sortType, page, pageSize);
            });
        }

        //[Fact]
        //public async Task GetAllFilteredAndSortedAndPagedAsync_Returns_Filtered_Restaurants_ByName_and_By_City()
        //{
        //    var stubRepo = createRepositoy();
        //    var service = new RestaurantService(stubRepo);
        //    RestaurantFilterDto filterDto = new RestaurantFilterDto { Name = "Bist", City = "Bel" };
        //    int sortType = 0;
        //    int page = 1;
        //    int pageSize = 1;

        //    var result = await service.GetAllFilteredAndSortedAndPagedAsync(filterDto, sortType, page, pageSize);

        //    result.ShouldNotBeNull();
        //    result.Items.Count.ShouldBe(1);
        //    result.Items.All(r => r.Name.Contains("Bist") && r.City.Contains("Bel")).ShouldBeTrue();
        //}

        //[Fact]
        //public async Task GetAllFilteredAndSortedAndPagedAsync_Returns_Sorted_Restaurants_ByName_Desc() 
        //{
        //    var stubRepo = createRepositoy();
        //    var service = new RestaurantService(stubRepo);
        //    RestaurantFilterDto filterDto = new RestaurantFilterDto { Name = "Bist", City = "Bel" };
        //    int sortType = 0;
        //    int page = 1;
        //    int pageSize = 1;

        //    var result = await service.GetAllFilteredAndSortedAndPagedAsync(filterDto, sortType, page, pageSize);

        //    result.Items.First().Name.ShouldBe("Bistro Nova");

        //}

        private IRestaurantRepository createRepositoy()
        {
            List<Restaurant> restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Bistro Nova",
                    Address = "Kralja Petra 12",
                    City = "Belgrade",
                    Description = "Modern Serbian cuisine with a twist.",
                    Capacity = 60, AverageRating = 6.5,
                    RestaurantOwnerId = 24
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "La Tavola",
                    Address = "Cara Dušana 45",
                    City = "Novi Sad",
                    Description = "Authentic Italian trattoria.",
                    Capacity = 80,
                    AverageRating = 9.5,
                    RestaurantOwnerId = 24
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Sakura Zen",
                    Address = "Bulevar Oslobođenja 88",
                    City = "Niš",
                    Description = "Japanese sushi bar with minimalist ambiance.",
                    Capacity = 40,
                    AverageRating = 8.2,
                    RestaurantOwnerId = 24
                },
                new Restaurant
                {
                    Id = 4,
                    Name = "Grill & Chill",
                    Address = "Trg Slobode 3",
                    City = "Subotica",
                    Description = "American-style BBQ with craft beers.",
                    Capacity = 100, AverageRating = 3.8,
                    RestaurantOwnerId = 24
                }
            };

            var stubRepository = new Mock<IRestaurantRepository>();

            stubRepository.Setup(repo => repo.GetBaseRestaurantsAsync())
                .ReturnsAsync(restaurants.AsQueryable());

            return stubRepository.Object;
        }
    }
}
