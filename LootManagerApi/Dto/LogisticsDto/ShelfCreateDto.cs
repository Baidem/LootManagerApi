using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class ShelfCreateDto
    {
        [Required] public string Name { get; set; }
        public int? IndiceOrDefault { get; set; } // if null => AutoIndice()
        [Required] public int FurnitureId { get; set; }
        [Required] public int NumberOfPositions { get; set; } // if > 0 => auto implement shelves

    }
}
