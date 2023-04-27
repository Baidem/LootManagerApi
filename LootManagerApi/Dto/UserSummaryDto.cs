using LootManagerApi.Entities;

namespace LootManagerApi.Dto
{
    public class UserSummaryDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public UserSummaryDto(User user)
        {
            UserId = user.Id;
            FullName = user.FullName;
            Email = user.Email;
        }
    }
}
