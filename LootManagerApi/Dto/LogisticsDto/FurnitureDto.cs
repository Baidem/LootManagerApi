using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class FurnitureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? LocationId { get; set; }
        public int ShelvesCount { get; set; }

        public FurnitureDto()
        {
        }

        public FurnitureDto(Furniture furniture)
        {
            Id = furniture.Id;
            Name = furniture.Name;
            Indice = furniture.Indice;
            UserId = furniture.UserId.Value;
            RoomId = furniture.RoomId;
            CreatedAt = furniture.CreatedAt;
            UpdatedAt = furniture.UpdatedAt;
            LocationId = furniture.LocationId;
            ShelvesCount = furniture.Shelves != null ? furniture.Shelves.Count : 0;
        }
    }

}
