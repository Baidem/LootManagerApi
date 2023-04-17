using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LootManagerApi.Dto;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string? House { get; set; }
        public string? Room { get; set; }
        public string? Furniture { get; set; }
        public string? Shelf { get; set; }
        public int? Position { get; set; }

        // Navigation properties
        public int? UserId { get; set; }
        public User? User { get; set; }
        public List<Element> Elements { get; set; }

        public Location()
        {
        }

        public Location(LocationCreateDto locationCreateDto, int userId)
        {
            House = locationCreateDto.House;
            Room = locationCreateDto.Room;
            Furniture = locationCreateDto.Furniture;
            Shelf = locationCreateDto.Shelf;
            Position = locationCreateDto.Position;
            UserId = userId;
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }

        public string GetLocationAddress()
        {
            return $"{House}-{Room}-{Furniture}-{Shelf}-{Position}";
        }
    }
}
