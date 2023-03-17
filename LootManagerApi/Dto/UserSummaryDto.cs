using LootManagerApi.Entities;

namespace LootManagerApi.Dto
{
    public class UserSummaryDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserSummaryDto(User user)
        {
            FullName = user.FullName;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
        }
    }
}
