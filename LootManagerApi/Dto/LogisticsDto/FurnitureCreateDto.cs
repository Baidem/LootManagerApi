using LootManagerApi.Entities.logistics;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class FurnitureCreateDto
    {
        [Required] public string Name { get; set; }
        public int? IndiceOrDefault { get; set; } // if null => AutoIndice()
        [Required] public int RoomId { get; set; }
        [Required] public int NumberOfShelves { get; set; } // if > 0 => auto implement shelves
        public int NumberOfPositionsPerShelf { get; set; } // if > 0 => auto implement positions ; if NumberOfShelves = 0 (or null) =>  the field is ignored

        public FurnitureCreateDto()
        {
        }
    }
}
