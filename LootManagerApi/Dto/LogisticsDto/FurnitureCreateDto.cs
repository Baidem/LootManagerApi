using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class FurnitureCreateDto
    {
        [Required] public string Name { get; set; }
        public int? IndiceOrDefault { get; set; } // if null => AutoIndice()
        [Required] public int RoomId { get; set; }
        [Required] public int NumberOfShelves { get; set; } // if > 0 => auto implement shelves
        [Required] public int NumberOfPositionsPerShelf { get; set; } // if > 0 => auto implement positions ; if NumberOfShelves = 0 (or null) =>  the field is ignored

        public FurnitureCreateDto()
        {
        }
    }
}
