using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Entities.logistics
{
    public class Shelf
    {
        #region PROPERTIES

        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region NAVIGATION PROPERTIES (3)

        // One Shelf? To One Location?
        public int LocationId { get; set; }
        public Location Location { get; set; }


        // One Furniture To Many Shelf?
        public int FurnitureId { get; set; }
        public Furniture Furniture { get; set; }

        // One Shelf To Many Position?
        public List<Position>? Positions { get; set; }

        // One User To Many Shelf
        public int? UserId { get; set; }
        public User? User { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Shelf()
        {
        }

        public Shelf(ShelfCreateDto shelfCreateDto, LocationDto locationDto)
        {
            if (shelfCreateDto.IndiceOrDefault == null)
                throw new ArgumentNullException("shelfCreateDto.IndiceOrDefault is null");

            Name = shelfCreateDto.Name;
            Indice = shelfCreateDto.IndiceOrDefault.Value;
            CreatedAt = locationDto.CreatedAt;
            LocationId = locationDto.LocationId;
            FurnitureId = shelfCreateDto.FurnitureId;
            UserId = locationDto.UserId;
        }

        #endregion
    }
}
