using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class RoomUpdateDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int HouseId { get; set; }
        [Required] public int Indice { get; set; }
    }
}
