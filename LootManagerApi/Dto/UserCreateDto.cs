using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto
{
    public class UserCreateDto
    {
        [Required] public string FullName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}
