using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using LootManagerApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities;
using LootManagerApi.Repositories.Interfaces;
using LootManagerApi.Entities.logistics;
using System.Xml.Linq;

namespace LootManagerApi.Repositories.Tests
{
    [TestClass()]
    public class HouseRepositoryTests
    {
        private LootManagerContext _context;
        private HouseRepository _houseRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            var builder = new DbContextOptionsBuilder<LootManagerContext>().UseInMemoryDatabase("LootManagerTest");
            _context = new LootManagerContext(builder.Options);
            _houseRepository = new HouseRepository(_context, null);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod()]
        public async Task CreateHouseAsyncTest_ValidHouseCreateDto_ReturnsHouseDto()
        {
            // Arrange
            var name = "Test";
            var indice = 2;
            var userId = 1;

            var houseCreateDto = new HouseCreateDto
            {
                Name = name,
                Indice = indice
            };

            var myHouse = new House
            {
                Id = 1,
                Name = "My House",
                Indice = 1,
                UserId = userId
            };

            _context.Add(myHouse);

            await _context.SaveChangesAsync();

            // Act
            var houseDto = await _houseRepository.CreateHouseByDtoAsync(houseCreateDto, userId);
            Console.Error.WriteLine("houseDto");
            Console.Error.WriteLine(houseDto);
            var house = await _context.Houses.FirstAsync(h => h.Name == houseCreateDto.Name);
            Console.Error.WriteLine("house");
            Console.Error.WriteLine(house);

            // Assert
            var expected_houseDto = new HouseDto
            {
                Id = 2,
                Name = name,
                Indice = indice,
                UserId = userId,
                CreatedAt = houseDto.CreatedAt            };
            Console.Error.WriteLine("expected_houseDto");
            Console.Error.WriteLine(expected_houseDto);

            var expected_house = new House
            {
                Id = 2,
                Name = name,
                Indice = indice,
                UserId = userId,
                CreatedAt = house.CreatedAt
            };
            Console.Error.WriteLine("expected_house");
            Console.Error.WriteLine(expected_house);

            Assert.AreEqual(houseDto.ToString(), expected_houseDto.ToString());
            Assert.AreEqual(house.ToString(), expected_house.ToString());
        }

        [TestMethod()]
        public async Task CreateHouseAsyncTest_IndiceNull_ThrowException()
        {
            // Arrange
            var name = "Test";
            var userId = 1;

            var houseCreateDto = new HouseCreateDto
            {
                Name = name,
                Indice = null
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _houseRepository.CreateHouseByDtoAsync(houseCreateDto, userId));
            Assert.AreEqual("An error occurred while creating the House : Value cannot be null. (Parameter 'houseCreateDto.Indice is null')", exception.Message);
        }


    }
}