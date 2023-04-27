using LootManagerApi.Repositories;
using LootManagerApi.Dto;
using LootManagerApi.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            // Arrange
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
            // Arrange
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
            // Arrange
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
            // Arrange
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

        [TestMethod()]
        public async Task IsValidUserCreateDtoAsyncTest_ValidUser_ReturnsTrue()
        {
            // Arrange
            var userCreateDto = new UserCreateDto
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                Password = "Thetest123$",
            };

            // Act
            var result = await _userRepository.CheckUserCreateDtoAsync(userCreateDto);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public async Task IsValidUserCreateDtoAsyncTest_InvalidEmail_ThrowsException()
        {
            // Arrange
            var userCreateDto = new UserCreateDto
            {
                FullName = "John Doe",
                Email = "john.doeexample.com", // invalid email format
                Password = "Thetest123$"
            };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserCreateDtoAsync(userCreateDto));
        }

        [TestMethod()]
        public async Task IsValidUserCreateDtoAsyncTest_EmailAlreadyExists_ThrowsException()
        {
            // Arrange
            var userCreateDto = new UserCreateDto
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                Password = "Thetest123$"
            };

            // Insert a user with the same email address in the database
            var existingUser = new User(userCreateDto);
            await _context.Users.AddAsync(existingUser);
            await _context.SaveChangesAsync();

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserCreateDtoAsync(userCreateDto));
        }

        [TestMethod()]
        public async Task IsValidUserCreateDtoAsyncTest_InvalidPasswordLength_ThrowsException()
        {
            // Arrange
            var userCreateDto = new UserCreateDto
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                Password = "test" // password too short
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserCreateDtoAsync(userCreateDto));
            Assert.AreEqual($"The password must have at least {Utils.UtilsPassword.PASSWORD_MIN_LENGTH} characters.", exception.Message);
        }

        [TestMethod()]
        public async Task IsValidUserCreateDtoAsyncTest_InvalidPasswordComplexity_ThrowsException()
        {
            // Arrange
            var userCreateDto = new UserCreateDto
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                Password = "Thetest123" // password missing special character
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserCreateDtoAsync(userCreateDto));
            Assert.AreEqual("The password must contain at least one upper case letter, one lower case letter, one number and one special character.", exception.Message);
        }

        [TestMethod()]
        public async Task CheckUserUpdateDtoAuthAsyncTest_ValidData_ReturnTrue()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                CurrentFullName = user.FullName,
                NewFullName = "Update User",
                CurrentEmail = user.Email,
                NewEmail = "update.user@example.com",
                CurrentPassword = "PasswordTest@1",
                NewPassword = "NewPassword@1",
            };

            UserAuthDto userAuthDto = new UserAuthDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = "User"
            };

            // Act and Assert
            Assert.IsTrue(await _userRepository.CheckUserUpdateDtoAuthAsync(userUpdateDto, userAuthDto));
        }

        [TestMethod()]
        public async Task CheckUserUpdateDtoAuthAsyncTest_DifferentEmail_ThrowsException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                CurrentFullName = user.FullName,
                NewFullName = "Update User",
                CurrentEmail = "different@exemple.com",
                NewEmail = "update.user@example.com",
                CurrentPassword = "PasswordTest@1",
                NewPassword = "NewPassword@1",
            };

            UserAuthDto userAuthDto = new UserAuthDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = "User"
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserUpdateDtoAuthAsync(userUpdateDto, userAuthDto));

            Assert.AreEqual("The CurrentEmail is not correct.", exception.Message);
        }

        [TestMethod()]
        public async Task CheckUserUpdateDtoAuthAsyncAsyncTest_DifferentPassword_ThrowsException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                CurrentFullName = user.FullName,
                NewFullName = "Update User",
                CurrentEmail = user.Email,
                NewEmail = "update.user@example.com",
                CurrentPassword = "Different@1",
                NewPassword = "NewPassword@1",
            };

            UserAuthDto userAuthDto = new UserAuthDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = "User"
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserUpdateDtoAuthAsync(userUpdateDto, userAuthDto));

            Assert.AreEqual("The CurrentPassword is not correct.", exception.Message);
        }

        [TestMethod()]
        public async Task ValidateUserUpdateDtoDataAsyncTest_ValidData_ReturnTrue()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                CurrentFullName = user.FullName,
                NewFullName = "Update User",
                CurrentEmail = user.Email,
                NewEmail = "update.user@example.com",
                CurrentPassword = "PasswordTest@1",
                NewPassword = "NewPassword@1",
            };

            // Act and Assert
            Assert.IsTrue(await _userRepository.CheckUserUpdateDtoNewDataAsync(userUpdateDto));
        }

        [TestMethod()]
        public async Task ValidateUserUpdateDtoDataAsyncTest_InvalidEmailFormat_ThrowsException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                CurrentFullName = user.FullName,
                NewFullName = "Update User",
                CurrentEmail = user.Email,
                NewEmail = "Invalid Format!",
                CurrentPassword = "PasswordTest@1",
                NewPassword = "NewPassword@1",
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserUpdateDtoNewDataAsync(userUpdateDto));

            Assert.AreEqual("Invalid email address format : Invalid Format!", exception.Message);
        }

        [TestMethod()]
        public async Task ValidateUserUpdateDtoDataAsyncTest_EmailUsed_ThrowsException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };

            var user2 = new User
            {
                Id = 2,
                FullName = "Test User2",
                Email = "testuser2@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@2"),
                Role = UserRole.User
            };

            _context.Users.Add(user);
            _context.Users.Add(user2);
            await _context.SaveChangesAsync();

            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                CurrentFullName = user.FullName,
                NewFullName = "Update User",
                CurrentEmail = user.Email,
                NewEmail = user2.Email,
                CurrentPassword = "PasswordTest@1",
                NewPassword = "NewPassword@1",
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserUpdateDtoNewDataAsync(userUpdateDto));

            Assert.AreEqual("Email is already used : testuser2@example.com", exception.Message);
        }

        [TestMethod()]
        public async Task ValidateUserUpdateDtoDataAsyncTest_PasswordTooShort_ThrowsException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };

            var user2 = new User
            {
                Id = 2,
                FullName = "Test User2",
                Email = "testuser2@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@2"),
                Role = UserRole.User
            };

            _context.Users.Add(user);
            _context.Users.Add(user2);
            await _context.SaveChangesAsync();

            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                CurrentFullName = user.FullName,
                NewFullName = "Update User",
                CurrentEmail = user.Email,
                CurrentPassword = "PasswordTest@1",
                NewPassword = "Short",
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserUpdateDtoNewDataAsync(userUpdateDto));

            Assert.AreEqual($"The password must have at least {Utils.UtilsPassword.PASSWORD_MIN_LENGTH} characters.", exception.Message);
        }

        [TestMethod()]
        public async Task ValidateUserUpdateDtoDataAsyncTest_PasswordTooSimple_ThrowsException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };

            var user2 = new User
            {
                Id = 2,
                FullName = "Test User2",
                Email = "testuser2@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@2"),
                Role = UserRole.User
            };

            _context.Users.Add(user);
            _context.Users.Add(user2);
            await _context.SaveChangesAsync();

            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                CurrentFullName = user.FullName,
                NewFullName = "Update User",
                CurrentEmail = user.Email,
                CurrentPassword = "PasswordTest@1",
                NewPassword = "simplepassword",
            };

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.CheckUserUpdateDtoNewDataAsync(userUpdateDto));

            Assert.AreEqual("The password must contain at least one upper case letter, one lower case letter, one number and one special character.", exception.Message);
        }

        [TestMethod()]
        public async Task UpdateUserRoleAsyncTest_ValidId_ReturnUserSummaryDto()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            UserSummaryDto userSummaryDto = await _userRepository.UpdateUserRoleAsync(1, UserRole.Admin);

            // Assert
            Assert.IsNotNull(userSummaryDto);
            Assert.AreEqual(userSummaryDto.FullName, user.FullName);
            Assert.AreEqual(userSummaryDto.Email, user.Email);
            Assert.AreEqual(user.Role, UserRole.Admin);
        }

        [TestMethod()]
        public async Task UpdateUserRoleAsyncTest_UnvalidId_ThrowsException()
        {
            // Arrange
            var user = new User
            {
                Id = 2,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.UpdateUserRoleAsync(1, UserRole.Admin));

            Assert.AreEqual("The user cannot be found.", exception.Message);
        }

        [TestMethod()]
        public async Task DeleteAsyncTest_ValidId_ReturnUserSummaryDto()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            UserSummaryDto userSummaryDto = await _userRepository.DeleteUserAsync(1);
            var userNull = await _context.Users.FirstOrDefaultAsync(u => u.Id == 1);

            // Assert
            Assert.IsNotNull(userSummaryDto);
            Assert.AreEqual(userSummaryDto.FullName, user.FullName);
            Assert.AreEqual(userSummaryDto.Email, user.Email);
            Assert.IsNull(userNull);
        }

        [TestMethod()]
        public async Task DeleteAsyncTest_UnvalidId_ThrowsException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.DeleteUserAsync(2));

            Assert.AreEqual("The user cannot be found.", exception.Message);
        }

        [TestMethod()]
        public async Task IsUserExistByIdAsyncTest_ValidId_ReturnTrue()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act and Assert
            Assert.IsTrue(await _userRepository.IsUserExistByIdAsync(user.Id));
        }

        [TestMethod()]
        public async Task IsUserExistByIdAsyncTest_UnvalidId_ThrowsException()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FullName = "Test User",
                Email = "testuser@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("PasswordTest@1"),
                Role = UserRole.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act & Assert
            var exception = await Assert.ThrowsExceptionAsync<Exception>(() => _userRepository.IsUserExistByIdAsync(2));

            Assert.AreEqual($"User with ID 2 does not exist in the database.", exception.Message);
        }

    }
}
