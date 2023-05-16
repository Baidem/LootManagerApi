using LootManagerApi.Dto.LogisticsDto;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Entities.logistics
{
    public class House : Unit
    {
        // PROPERTIES

        // NAVIGATION PROPERTIES (3)

        // One User To Many House
        public int UserId { get; set; }
        public User User { get; set; }

        // One House? To One Location?
        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        // One House To Many Rooms?
        public List<Room>? Rooms { get; set; }


        // CONSTRUCTORS

        public House()
        {
        }

        public House(HouseCreateDto houseCreateDto, LocationDto locationDto)
        {
            if (houseCreateDto.IndiceOrDefault == null)
                throw new Exception("House.Indice can't be null.");

            Name = houseCreateDto.Name;
            Indice = houseCreateDto.IndiceOrDefault.Value;
            CreatedAt = locationDto.CreatedAt;
            UserId = locationDto.UserId;
            LocationId = locationDto.LocationId;
        }

        // METHODS

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }
    }
}
