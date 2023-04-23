using LootManagerApi.Entities.logistics;
using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class RoomUpdateDto
    {
        [Required] public int Id { get; set; }
        public string? Name { get; set; }
        public int? Indice { get; set; }
        public int? HouseId { get; set; }
    }
}
