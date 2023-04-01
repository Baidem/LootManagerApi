using System.Text.Json.Serialization;

namespace LootManagerApi.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRole
    {
        Admin,
        User,
        Contributor
    }
}
