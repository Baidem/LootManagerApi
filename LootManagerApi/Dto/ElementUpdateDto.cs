using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto
{
    public class ElementUpdateDto
    {
        [Required] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
    }
}
