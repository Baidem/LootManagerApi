using LootManagerApi.Entities;

namespace LootManagerApi.Dto
{
    public class ElementDto
    {
        public int Id { get; set; }
        public string Name { get; set; } // The name given by the user
        public string? Description { get; set; } // The description given by the user
        public string? Type { get; set; } // The object type
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? LocationId { get; set; }

        public ElementDto(Element element)
        {
            Id = element.Id;
            Name = element.Name;
            Description = element.Description;
            Type = element.Type;
            CreatedAt = element.CreatedAt;
            UpdatedAt = element?.UpdatedAt;
            LocationId = element?.LocationId;
        }
    }
}
