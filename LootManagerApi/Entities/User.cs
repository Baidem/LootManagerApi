using LootManagerApi.Dto;
using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserRole Role { get; set; }
        public string? AuthorSignature { get; set; }

        // NAVIGATION PROPERTIES (3)

        // One User To Many Element?
        public List<Element> Elements { get; set; }

        // One User To Many InfoSheet?
        public List<InfoSheet>? InfoSheets { get; set; }

        //One User To Many House
        public List<House> Houses { get; set; }

        public User()
        {
        }

        public User(UserCreateDto userCreateDto)
        {
            FullName = userCreateDto.FullName;
            Email = userCreateDto.Email;
            PasswordHash = Utils.UtilsPassword.GenerateHashedPassword(userCreateDto.Password);
            CreatedAt = DateTime.UtcNow;
            Role = UserRole.User;
        }
    }
}