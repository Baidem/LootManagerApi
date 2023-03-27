using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Dto
{
    public class ElementUpdateDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Type { get; set; }
    }
}
