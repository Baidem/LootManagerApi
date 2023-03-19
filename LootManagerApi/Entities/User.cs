using LootManagerApi.Dto;

namespace LootManagerApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        // Navigation properties
        public List<Element> Elements { get; set; }
        public List<Location> Locations { get; set; }

        public User()
        {
        }

        public User(UserCreateDto userCreateDto)
        {
            FullName = userCreateDto.FullName;
            Email = userCreateDto.Email;
            PasswordHash = Utils.UtilsPassword.GenerateHashedPassword(userCreateDto.Password);
            CreatedAt = DateTime.UtcNow;
        }
    }
}