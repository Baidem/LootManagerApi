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
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

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

            // Test datas
            var userLoginDto = new UserLoginDto
            {
                Email = "invalid-email-format",
                Password = "test"
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserLoginDtoAsync(userLoginDto));
            Assert.AreEqual("Invalid email address attribute : invalid-email-format", exception.Message);
        }

        [TestMethod()]
        public async Task CheckUserLoginDtoAsync_NotExistEmail_ThrowsException()
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

            // Test datas
            var userLoginDto = new UserLoginDto
            {
                Email = "notexiste@loot.com",
                Password = "test"
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserLoginDtoAsync(userLoginDto));
            Assert.AreEqual("Email does not exist : notexiste@loot.com", exception.Message);
        }

        [TestMethod()]
        public async Task CheckUserLoginDtoAsync_BadPassword_ThrowsException()
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

            // Test datas
            var userLoginDto = new UserLoginDto
            {
                Email = "user5@loot.com",
                Password = "badPassword"
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserLoginDtoAsync(userLoginDto));
            Assert.AreEqual("The password is invalid.", exception.Message);
        }

        [TestMethod]
        public async Task GetClaimsIdentityAsync_ValidUser_ReturnsClaimsIdentity()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = "testpasswordhash",
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userLoginDto = new UserLoginDto
            {
                Email = "testuser@example.com",
                Password = "testpassword"
            };

            // Act
            var identity = await _userRepository.GetClaimsIdentityAsync(userLoginDto);

            // Assert
            Assert.IsNotNull(identity);
            Assert.AreEqual(CookieAuthenticationDefaults.AuthenticationScheme, identity.AuthenticationType);
            Assert.IsTrue(identity.Claims.Any(c => c.Type == ClaimTypes.NameIdentifier && c.Value == "1"));
            Assert.IsTrue(identity.Claims.Any(c => c.Type == ClaimTypes.Name && c.Value == "Test User"));
            Assert.IsTrue(identity.Claims.Any(c => c.Type == ClaimTypes.Email && c.Value == "testuser@example.com"));
            Assert.IsTrue(identity.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == UserRole.User.ToString()));
        }

        [TestMethod]
        public async Task GetClaimsIdentityAsync_InvalidUser_ThrowsException()
        {
            // Arrange
            var userLoginDto = new UserLoginDto { Email = "invaliduser@example.com" };

            // Act and Assert
            await Assert.ThrowsExceptionAsync<NullReferenceException>(() => _userRepository.GetClaimsIdentityAsync(userLoginDto));
        }

        [TestMethod()]
        public async Task GetAllUsersAsyncTest_ValidList_ReturnsTrue()
        {
            // Arrange
            var u1 = new User
            {
                Id = 1,
                FullName = "admin",
                Email = "admin@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.Admin
            };
            var u2 = new User
            {
                Id = 2,
                FullName = "user",
                Email = "user@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.User
            };
            var u3 = new User
            {
                Id = 3,
                FullName = "contributor",
                Email = "contributor@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.Contributor
            };
            var u4 = new User
            {
                Id = 4,
                FullName = "user4",
                Email = "user4@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.User
            };
            var u5 = new User
            {
                Id = 5,
                FullName = "user5",
                Email = "user5@loot.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.User
            };

            _context.Add(u1);
            _context.Add(u2);
            _context.Add(u3);
            _context.Add(u4);
            _context.Add(u5);

            await _context.SaveChangesAsync();

            // Act
            List<UserSummaryDto> list = await _userRepository.GetAllUsersAsync();

            // Assert
            Assert.AreEqual(list.Count, 5);
        }

        [TestMethod()]
        public async Task GetAllUsersAsyncTest_EmptyList_Returns()
        {
            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.GetAllUsersAsync());
            Assert.AreEqual("Empty list, no users are registered.", exception.Message);
        }

    }
}
