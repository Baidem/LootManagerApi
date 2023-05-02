using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Entities.logistics
{
    public class Room
    {
        #region PROPERTIES

        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region NAVIGATION PROPERTIES (4)

        // One Room? To One Location?
        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        // One Room To Many Room?
        public int HouseId { get; set; }
        public House House { get; set; }

        // One Room To Many Furniture?
        public List<Furniture>? Furnitures { get; set; }

        // One User To Many Room
        public int? UserId { get; set; }
        public User? User { get; set; }

        #endregion

        #region CONSTRUCTOR

        public Room()
        {
        }

        public Room(RoomCreateDto roomCreateDto, LocationDto locationDto)
        {
            if (roomCreateDto.IndiceOrDefault == null)
                throw new ArgumentNullException("roomCreateDto.IndiceOrDefault is null");

            Name = roomCreateDto.Name;
            Indice = roomCreateDto.IndiceOrDefault.Value;
            CreatedAt = locationDto.CreatedAt;
            LocationId = locationDto.LocationId;
            HouseId = roomCreateDto.HouseId;
            UserId = locationDto.UserId;
        }

        #endregion
    }
}
