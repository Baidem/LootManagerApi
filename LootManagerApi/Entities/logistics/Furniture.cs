using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Entities.logistics
{
    public class Furniture
    {
        #region PROPERTIES

        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public int NumberOfShelves { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region NAVIGATION PROPERTIES (4)

        // One Furniture? To One Location?
        public int? LocationId { get; set; }
        public Location? Location { get; set; }


        // One Room To Many Furniture?
        public int RoomId { get; set; }
        public Room Room { get; set; }

        // One Furniture To Many Shelf?
        public List<Shelf>? Shelves { get; set; }

        // One User To Many Furniture
        public int? UserId { get; set; }
        public User? User { get; set; }

        #endregion

        #region CONSTRUCTOR

        public Furniture()
        {
        }

        public Furniture(FurnitureCreateDto furnitureCreateDto, LocationDto locationDto)
        {
            if (furnitureCreateDto.IndiceOrDefault == null)
                throw new Exception("Furniture.Indice can't be null.");

            Name = furnitureCreateDto.Name;
            Indice = furnitureCreateDto.IndiceOrDefault.Value;
            NumberOfShelves = furnitureCreateDto.NumberOfShelves;
            CreatedAt = locationDto.CreatedAt;
            RoomId = furnitureCreateDto.RoomId;
            UserId = locationDto.UserId;
            LocationId = locationDto.LocationId;
        }

        #endregion

    }
}
