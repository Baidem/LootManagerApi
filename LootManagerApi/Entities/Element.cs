using LootManagerApi.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Entities
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

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