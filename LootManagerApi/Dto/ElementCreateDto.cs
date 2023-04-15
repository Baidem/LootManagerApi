using LootManagerApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto
{
    public class ElementCreateDto
    {
        [Required] public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
    }
}
