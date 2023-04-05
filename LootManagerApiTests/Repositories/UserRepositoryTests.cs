using Microsoft.VisualStudio.TestTools.UnitTesting;
using LootManagerApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LootManagerApi.Entities;
using System.Reflection.Emit;
using LootManagerApi.Dto;
using LootManagerApi.Utils;

namespace LootManagerApi.Repositories.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        private LootManagerContext _context;
        private UserRepository _userRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            var builder = new DbContextOptionsBuilder<LootManagerContext>().UseInMemoryDatabase("LootManagerTest");
            _context = new LootManagerContext(builder.Options);
            _userRepository = new UserRepository(_context, null);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod()]
        public async Task CheckUserLoginDtoAsync_ValidUserLoginDto_ReturnsTrue()
        {
            // Bdd Datas
            var u5 = new User
            {
                Id = 5,
                FullName = "user5",
                Email = "user5@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.User
            };

            _context.Add(u5);

            await _context.SaveChangesAsync();

            // Act
            var test = new UserLoginDto
            {
                Email = "user5@loot.com",
                Password = "test"
            };

            var result = await _userRepository.CheckUserLoginDtoAsync(test);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public async Task CheckUserLoginDtoAsync_InvalidEmailFormat_ThrowsException()
        {
            // Bdd Datas
            var u5 = new User
            {
                Id = 5,
                FullName = "user5",
                Email = "user5@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.User
            };

            _context.Add(u5);

            await _context.SaveChangesAsync();

            // Act
            var userLoginDto = new UserLoginDto
            {
                Email = "invalid-email-format",
                Password = "test"
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserLoginDtoAsync(userLoginDto));
            Assert.AreEqual("Invalid email address attribute : invalid-email-format", exception.Message);
        }
    }
}
