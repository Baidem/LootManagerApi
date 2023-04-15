using LootManagerApi.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Entities
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; } // The name given by the user
        public string Description { get; set; } // The description given by the user
        public string Type { get; set; } // The object type
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public int UserId { get; set; }
        public User User { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
        public List<Image>? Images { get; set; }

        public Element()
        {
        }

        public Element(ElementCreateDto elementCreateDto, int userId)
        {
            Name = elementCreateDto.Name;
            Description = elementCreateDto.Description;
            Type = elementCreateDto.Type;
            UserId = userId;
        }
    }
}