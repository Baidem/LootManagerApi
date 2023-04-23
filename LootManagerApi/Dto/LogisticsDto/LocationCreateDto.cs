using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class LocationCreateDto
    {
        [Required] public int UserId { get; set; }
        [Required] public int HouseId { get; set; }
        public int? RoomId { get; set; }
        public int? FurnitureId { get; set; }
        public int? ShelfId { get; set; }
        public int? PositionId { get; set; }
    }
}
