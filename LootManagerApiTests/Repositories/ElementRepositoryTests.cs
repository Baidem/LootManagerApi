using LootManagerApi.Dto;
using LootManagerApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LootManagerApi.Repositories.Tests
{
    [TestClass()]
    public class ElementRepositoryTests
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
        public async Task UpdateElementAsyncTest_ValidElementUpdateDto_ReturnElementDto()
        {
            // Arrange
            var name = "Test element";
            var description = "Test description";
            var type = "Test type";
            var userId = 1;
            var createdAt = DateTime.UtcNow;

            var element = new Element
            {
                Name = name,
                Description = description,
                Type = type,
                UserId = userId,
                CreatedAt = createdAt,
            };
            Console.Error.WriteLine("element before save :");
            Console.Error.WriteLine(element);

            await _context.Elements.AddAsync(element);
            await _context.SaveChangesAsync();
            Console.Error.WriteLine("element after save :");
            Console.Error.WriteLine(element);

            ElementUpdateDto elementUpdateDto = new ElementUpdateDto
            {
                Id = element.Id,
                Name = "Update element",
                Description = "Update description",
                Type = "Update type",
            };

            //Act
            ElementDto elementDto = await _elementRepository.UpdateElementAsync(elementUpdateDto);
            Console.Error.WriteLine("element after update :");
            Console.Error.WriteLine(element);

            var control = new Element
            {
                Id = element.Id,
                Name = elementUpdateDto.Name,
                Description = elementUpdateDto.Description,
                Type = elementUpdateDto.Type,
                UserId = userId,
                CreatedAt = createdAt,
                UpdatedAt = element.UpdatedAt,
                LocationId = element.LocationId,
            };
            Console.Error.WriteLine("controle object :");
            Console.Error.WriteLine(control);

            // Assert
            Assert.AreEqual(elementDto.Name, elementUpdateDto.Name);
            Assert.AreEqual(elementDto.Description, elementUpdateDto.Description);
            Assert.AreEqual(elementDto.Type, elementUpdateDto.Type);

            Assert.AreEqual(element.ToString(), control.ToString());
        }

        [TestMethod()]
        public async Task UpdateElementAsyncTest_EmptyElementUpdateDto_ThrowsException()
        {
            // Arrange
            var name = "Test element";
            var description = "Test description";
            var type = "Test type";
            var userId = 1;
            var createdAt = DateTime.UtcNow;

            var element = new Element
            {
                Name = name,
                Description = description,
                Type = type,
                UserId = userId,
                CreatedAt = createdAt,
            };
            Console.Error.WriteLine("element before save :");
            Console.Error.WriteLine(element);

            await _context.Elements.AddAsync(element);
            await _context.SaveChangesAsync();
            Console.Error.WriteLine("element after save :");
            Console.Error.WriteLine(element);

            ElementUpdateDto elementUpdateDto = new ElementUpdateDto
            {
                Id = element.Id,
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _elementRepository.UpdateElementAsync(elementUpdateDto));
            Assert.AreEqual("An error occurred while updating the element. No changes needed.", exception.Message);
        }

        [TestMethod()]
        public async Task UpdateElementAsyncTest_ChangeNameOnly_ReturnElementDto()
        {
            // Arrange
            var name = "Test element";
            var description = "Test description";
            var type = "Test type";
            var userId = 1;
            var createdAt = DateTime.UtcNow;

            var element = new Element
            {
                Name = name,
                Description = description,
                Type = type,
                UserId = userId,
                CreatedAt = createdAt,
            };
            Console.Error.WriteLine("element before save :");
            Console.Error.WriteLine(element);

            await _context.Elements.AddAsync(element);
            await _context.SaveChangesAsync();
            Console.Error.WriteLine("element after save :");
            Console.Error.WriteLine(element);

            ElementUpdateDto elementUpdateDto = new ElementUpdateDto
            {
                Id = element.Id,
                Name = "Update element",
            };

            //Act
            ElementDto elementDto = await _elementRepository.UpdateElementAsync(elementUpdateDto);
            Console.Error.WriteLine("element after update :");
            Console.Error.WriteLine(element);

            var control = new Element
            {
                Id = element.Id,
                Name = elementUpdateDto.Name,
                Description = description,
                Type = type,
                UserId = userId,
                CreatedAt = createdAt,
                UpdatedAt = element.UpdatedAt,
                LocationId = element.LocationId,
            };
            Console.Error.WriteLine("controle object :");
            Console.Error.WriteLine(control);

            // Assert
            Assert.AreEqual(elementDto.Name, elementUpdateDto.Name);
            Assert.AreEqual(elementDto.Description, description);
            Assert.AreEqual(elementDto.Type, type);

            Assert.AreEqual(element.ToString(), control.ToString());
        }

        [TestMethod()]
        public async Task UpdateElementAsyncTest_ChangeDescriptionOnly_ReturnElementDto()
        {
            // Arrange
            var name = "Test element";
            var description = "Test description";
            var type = "Test type";
            var userId = 1;
            var createdAt = DateTime.UtcNow;

            var element = new Element
            {
                Name = name,
                Description = description,
                Type = type,
                UserId = userId,
                CreatedAt = createdAt,
            };
            Console.Error.WriteLine("element before save :");
            Console.Error.WriteLine(element);

            await _context.Elements.AddAsync(element);
            await _context.SaveChangesAsync();
            Console.Error.WriteLine("element after save :");
            Console.Error.WriteLine(element);

            ElementUpdateDto elementUpdateDto = new ElementUpdateDto
            {
                Id = element.Id,
                Description = "Update description",
            };

            //Act
            ElementDto elementDto = await _elementRepository.UpdateElementAsync(elementUpdateDto);
            Console.Error.WriteLine("element after update :");
            Console.Error.WriteLine(element);

            var control = new Element
            {
                Id = element.Id,
                Name = name,
                Description = elementUpdateDto.Description,
                Type = type,
                UserId = userId,
                CreatedAt = createdAt,
                UpdatedAt = element.UpdatedAt,
                LocationId = element.LocationId,
            };
            Console.Error.WriteLine("controle object :");
            Console.Error.WriteLine(control);

            // Assert
            Assert.AreEqual(elementDto.Name, name);
            Assert.AreEqual(elementDto.Description, elementUpdateDto.Description);
            Assert.AreEqual(elementDto.Type, type);

            Assert.AreEqual(element.ToString(), control.ToString());
        }

        [TestMethod()]
        public async Task UpdateElementAsyncTest_ChangeTypeOnly_ReturnElementDto()
        {
            // Arrange
            var name = "Test element";
            var description = "Test description";
            var type = "Test type";
            var userId = 1;
            var createdAt = DateTime.UtcNow;

            var element = new Element
            {
                Name = name,
                Description = description,
                Type = type,
                UserId = userId,
                CreatedAt = createdAt,
            };
            Console.Error.WriteLine("element before save :");
            Console.Error.WriteLine(element);

            await _context.Elements.AddAsync(element);
            await _context.SaveChangesAsync();
            Console.Error.WriteLine("element after save :");
            Console.Error.WriteLine(element);

            ElementUpdateDto elementUpdateDto = new ElementUpdateDto
            {
                Id = element.Id,
                Type = "Update type",
            };

            //Act
            ElementDto elementDto = await _elementRepository.UpdateElementAsync(elementUpdateDto);
            Console.Error.WriteLine("element after update :");
            Console.Error.WriteLine(element);

            var control = new Element
            {
                Id = element.Id,
                Name = name,
                Description = description,
                Type = elementUpdateDto.Type,
                UserId = userId,
                CreatedAt = createdAt,
                UpdatedAt = element.UpdatedAt,
                LocationId = element.LocationId,
            };
            Console.Error.WriteLine("controle object :");
            Console.Error.WriteLine(control);

            // Assert
            Assert.AreEqual(elementDto.Name, name);
            Assert.AreEqual(elementDto.Description, description);
            Assert.AreEqual(elementDto.Type, elementUpdateDto.Type);

            Assert.AreEqual(element.ToString(), control.ToString());
        }
    }
}