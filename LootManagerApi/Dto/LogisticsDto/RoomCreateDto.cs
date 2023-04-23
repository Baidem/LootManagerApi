using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class RoomCreateDto
    {
        [Required] public string Name { get; set; }
        [Required] public int HouseId { get; set; }
        public int? Indice { get; set; }
    }
}
