using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class ShelfDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? LocationId { get; set; }
        public int? PositionCount { get; set; }

        public ShelfDto()
        {
        }

        public ShelfDto(Shelf shelf)
        {
            Id = shelf.Id;
            Name = shelf.Name;
            Indice = shelf.Indice;
            UserId = shelf.UserId.Value;
            CreatedAt = shelf.CreatedAt;
            UpdatedAt = shelf.UpdatedAt;
            LocationId = shelf.LocationId;

            if (shelf != null)
                PositionCount = shelf.Positions.Count;
        }
    }
}
