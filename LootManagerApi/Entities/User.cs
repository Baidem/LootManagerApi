using LootManagerApi.Dto;
using LootManagerApi.Entities.logistics;
using System.Reflection;
using System.Text;

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

        // NAVIGATION PROPERTIES (4)

        // One User To Many Element?
        public List<Element> Elements { get; set; }

        // One User To Many InfoSheet?
        public List<InfoSheet>? InfoSheets { get; set; }

        // One User To Many House
        public List<House> Houses { get; set; }

        // One User To Many Furniture
        //public List<Furniture> Furnitures { get; set; }

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

        #region METHODS

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }

        #endregion

    }
}