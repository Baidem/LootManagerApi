using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto
{
    public class UserUpdateDto
    {
        [Required] public string CurrentFullName { get; set; }
        public string? NewFullName { get; set; }
        [Required] public string CurrentEmail { get; set; }
        public string? NewEmail { get; set; }
        [Required] public string CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
