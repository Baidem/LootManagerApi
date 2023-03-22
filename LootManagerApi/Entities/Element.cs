using LootManagerApi.Dto;

namespace LootManagerApi.Entities
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        // Navigation properties
        public User User { get; set; }
        public int UserId { get; set; }
        public ElementLocation? ElementLocation { get; set; }
        public int ElementLocationId { get; set; }

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