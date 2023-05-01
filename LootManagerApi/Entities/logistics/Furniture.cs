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

        public Furniture(FurnitureCreateDto furnitureCreateDto, int userId)
        {
            if (furnitureCreateDto.IndiceOrDefault == null)
                throw new ArgumentNullException("furnitureCreateDto.Indice is null");

            Name = furnitureCreateDto.Name;
            Indice = furnitureCreateDto.IndiceOrDefault;
            NumberOfShelves = furnitureCreateDto.NumberOfShelves;
            CreatedAt = DateTime.UtcNow;
            RoomId = furnitureCreateDto.RoomId;
            UserId = userId;
        }

        #endregion

    }
}
