using LootManagerApi.Entities;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string? House { get; set; }
        public string? Room { get; set; }
        public string? Furniture { get; set; }
        public string? Shelf { get; set; }
        public int? Position { get; set; }

        public LocationDto()
        {
        }

        public LocationDto(Location location)
        {
            Id = location.Id;
            House = location.House;
            Room = location.Room;
            Furniture = location.Furniture;
            Shelf = location.Shelf;
            Position = location.Position;
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

    }
}
