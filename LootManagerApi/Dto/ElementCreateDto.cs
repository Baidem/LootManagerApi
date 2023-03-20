using LootManagerApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto
{
    public class ElementCreateDto
    {
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Type { get; set; }

    }
}
