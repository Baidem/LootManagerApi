using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto
{
    public class UserDto
    {
        #region PROPERTIES

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserRole Role { get; set; }
        public string? AuthorSignature { get; set; }
        public DefaultLocationDto? DefaultLocationDto { get; set; }

        #endregion

        #region CONSTRUCTORS

        public UserDto()
        {
        }

        public UserDto(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
            Role = user.Role;
            AuthorSignature = user.AuthorSignature;
            DefaultLocationDto = null;
        }

        public UserDto(User user, DefaultLocationDto defaultLocationDto)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
            Role = user.Role;
            AuthorSignature = user.AuthorSignature;
            DefaultLocationDto = defaultLocationDto;
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
