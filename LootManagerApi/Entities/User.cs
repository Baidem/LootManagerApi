using LootManagerApi.Dto;
using LootManagerApi.Entities.logistics;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Entities
{
    public class User
    {
        #region PROPERTIES

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserRole Role { get; set; }
        public string? AuthorSignature { get; set; }

        #endregion

        #region NAVIGATION PROPERTIES (9)

        // One User To Many Element?
        public List<Element> Elements { get; set; }

        // One User To Many InfoSheet?
        public List<InfoSheet>? InfoSheets { get; set; }

        // One User To Many House
        public List<House> Houses { get; set; }

        // One User To Many Room
        public List<Room>? Rooms { get; set; }

        // One User To Many Furniture
        public List<Furniture>? Furnitures { get; set; }

        // One User To Many Shelf
        public List<Shelf>? Shelves { get; set; }

        // One User To Many Position
        public List<Position>? Positions { get; set; }

        // One User To Many Location
        public List<Location>? Locations { get; set; }

        // One DefaultLocation To One User
        public DefaultLocation DefaultLocation { get; set; }


        #endregion

        #region CONSTRUCTORS

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

        #endregion

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