using LootManagerApi.Entities.logistics;
using LootManagerApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class HouseUpdateDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Indice { get; set; }
    }
}
