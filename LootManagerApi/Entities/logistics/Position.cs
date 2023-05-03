using LootManagerApi.Dto.LogisticsDto;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Entities.logistics
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // NAVIGATION PROPERTIES (3)

        // One Position? To One Location
        public int LocationId { get; set; }
        public Location Location { get; set; }

        // One Shelf To Many Position?
        public int ShelfId { get; set; }

        // One User To Many Position
        public int? UserId { get; set; }
        public User? User { get; set; }

        // CONSTRUCTORS
        public Position()
        {
        }

        public Position(PositionCreateDto positionCreateDto, LocationDto locationDto)
        {
            if (positionCreateDto.IndiceOrDefault == null)
                throw new Exception("Furniture.Indice can't be null.");

            if (positionCreateDto.Name == null)
                Name = "pos";
            else
                Name = positionCreateDto.Name;

            Indice = positionCreateDto.IndiceOrDefault.Value;
            CreatedAt = locationDto.CreatedAt;
            LocationId = locationDto.LocationId;
            ShelfId = positionCreateDto.ShelfId;
            UserId = locationDto.UserId;
        }
    }
}
