using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class PositionCreateDto
    {
        [Required] public string Name { get; set; }
        public int? IndiceOrDefault { get; set; } // if null => AutoIndice()
        [Required] public int ShelfId { get; set; }

        public PositionCreateDto()
        {
        }
    }
}
