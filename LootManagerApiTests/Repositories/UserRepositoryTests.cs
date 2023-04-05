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
        [TestMethod()]
        public async Task CheckUserLoginDtoAsync_ValidUserLoginDto_ReturnsTrue()
        {
            // Bdd
            var builder = new DbContextOptionsBuilder<LootManagerContext>().UseInMemoryDatabase("LootManagerTest");

            // Context
            var context = new LootManagerContext(builder.Options);
            UserRepository userRepository = new UserRepository(context, null);

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

            context.Add(u5);

            await context.SaveChangesAsync();

            // Act
            var test = new UserLoginDto
            {
                Email = "user5@loot.com",
                Password = "test"
            };

            var result = await userRepository.CheckUserLoginDtoAsync(test);

            // Assert
            Assert.IsTrue(result);

            // Bdd delete
            context.Database.EnsureDeleted();
        }
        [TestMethod()]
        public async Task CheckUserLoginDtoAsync_InvalidEmailFormat_ThrowsException()
        {
            // Bdd
            var builder = new DbContextOptionsBuilder<LootManagerContext>().UseInMemoryDatabase("LootManagerTest");

            // Context
            var context = new LootManagerContext(builder.Options);
            UserRepository userRepository = new UserRepository(context, null);

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

            context.Add(u5);

            await context.SaveChangesAsync();

            // Act
            var userLoginDto = new UserLoginDto
            {
                Email = "invalid-email-format",
                Password = "test"
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => userRepository.CheckUserLoginDtoAsync(userLoginDto));
            Assert.AreEqual("Invalid email address attribute : invalid-email-format", exception.Message);

            // Bdd delete
            context.Database.EnsureDeleted();
        }

    }
}