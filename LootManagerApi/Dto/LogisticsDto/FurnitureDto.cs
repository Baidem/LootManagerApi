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
        public int LocationId { get; set; }

        public FurnitureDto()
        {
        }

        public FurnitureDto(Furniture furniture)
        {
            Id =furniture.Id;
            Name = furniture.Name;
            Indice = furniture.Indice;
            UserId = furniture.RoomId;
            RoomId = furniture.RoomId;
            //LocationId = furniture.LocationId; // TODO mise à jour des clés de Location
        }
    }
      
}
