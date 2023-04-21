using LootManagerApi.Entities.logistics;
using LootManagerApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class HouseUpdateDto
    {
        [Required] public int Id { get; set; }
        public string? Name { get; set; }
        public int? Indice { get; set; }
    }
}
