using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class DefaultLocationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }

        public DefaultLocationDto(DefaultLocation defaultLocation)
        {
            Id = defaultLocation.Id;
            UserId = defaultLocation.UserId.Value;
            LocationId = defaultLocation.LocationId.Value;
        }
    }
}
