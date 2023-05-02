using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public int UserId { get; set; }
        public int ShelfId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? LocationId { get; set; }

        public PositionDto()
        {
        }

        public PositionDto(Position position)
        {
            Id = position.Id;
            Name = position.Name;
            Indice = position.Indice;
            UserId = position.UserId.Value;
            ShelfId = position.ShelfId;
            CreatedAt = position.CreatedAt;
            UpdatedAt = position.UpdatedAt;
            LocationId = position.LocationId;
        }
    }
}
