using System.Security.Claims;

namespace LootManagerApi.Dto
{
    public class UserAuthDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public UserAuthDto()
        {
        }

        public UserAuthDto(ClaimsIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity), "The 'identity' parameter cannot be null.");
            }

            var nameIdentifierClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
            if (nameIdentifierClaim == null)
            {
                throw new ArgumentException($"The '{ClaimTypes.NameIdentifier}' claim is missing.", nameof(identity));
            }

            var nameClaim = identity.FindFirst(ClaimTypes.Name);
            if (nameClaim == null)
            {
                throw new ArgumentException($"The '{ClaimTypes.Name}' claim is missing.", nameof(identity));
            }

            var emailClaim = identity.FindFirst(ClaimTypes.Email);
            if (emailClaim == null)
            {
                throw new ArgumentException($"The '{ClaimTypes.Email}' claim is missing.", nameof(identity));
            }

            var roleClaim = identity.FindFirst(ClaimTypes.Role);
            if (roleClaim == null)
            {
                throw new ArgumentException($"The '{ClaimTypes.Role}' claim is missing.", nameof(identity));
            }

            if (!int.TryParse(nameIdentifierClaim.Value, out int id))
            {
                throw new ArgumentException($"The '{ClaimTypes.NameIdentifier}' claim value is not a valid integer.", nameof(identity));
            }

            Id = id;
            FullName = nameClaim.Value;
            Email = emailClaim.Value;
            Role = roleClaim.Value;
        }

    }
}
