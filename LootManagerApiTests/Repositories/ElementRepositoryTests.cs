using Microsoft.VisualStudio.TestTools.UnitTesting;
using LootManagerApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LootManagerApi.Dto;
using LootManagerApi.Entities;

namespace LootManagerApi.Repositories.Tests
{
    [TestClass()]
    public class ElementRepositoryTests_ValidElementUpdateDto_ReturnElementDto
    {
        private LootManagerContext _context;
        private ElementRepository _elementRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            var builder = new DbContextOptionsBuilder<LootManagerContext>().UseInMemoryDatabase("LootManagerTest");
            _context = new LootManagerContext(builder.Options);
            _elementRepository = new ElementRepository(_context, null);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod()]
        public async void UpdateElementAsyncTest()
        {
            // Arrange
            var element = new Element
            {
                Id = 1,
                Name = "Test element",
                Description = "Test description",
                Type = "Test type",
                CreatedAt = DateTime.Now
            };
            _context.Elements.Add(element);
            await _context.SaveChangesAsync();

            ElementUpdateDto elementUpdateDto = new ElementUpdateDto
            {
                Name = "Update element",
                Description = "Update description",
                Type = "Update type",
            };

            // Act
            ElementDto elementDto = await _elementRepository.UpdateElementAsync(elementUpdateDto);
            Element? elementUpdated = await _context.Elements.FirstOrDefaultAsync(e => e.Name == elementUpdateDto.Name);

            // AssertelementDtossert.IsNotNull(elementDto);
            Assert.AreEqual(elementDto.Name, elementUpdateDto.Name);
            Assert.AreEqual(elementDto.Description, elementUpdateDto.Description);
            Assert.AreEqual(elementDto.Type, elementUpdateDto.Type);
            Assert.IsNotNull(elementDto.CreatedAt);
            Assert.IsNotNull(elementDto.UpdatedAt);

            Assert.IsNotNull(elementUpdated);
            Assert.IsNotNull(elementUpdated.Id);
            Assert.AreEqual(elementUpdated.Name, elementUpdateDto.Name);
            Assert.AreEqual(elementUpdated.Description, elementUpdateDto.Description);
            Assert.AreEqual(elementUpdated.Type, elementUpdateDto.Type);
            Assert.AreEqual(elementUpdated.CreatedAt, elementDto.CreatedAt);
            Assert.AreEqual(elementUpdated.UpdatedAt, elementDto.UpdatedAt);
        }
    }
}