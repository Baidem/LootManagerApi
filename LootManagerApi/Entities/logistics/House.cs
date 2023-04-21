using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Entities.logistics
{
    public class House
    {
        #region PROPERTIES

        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region NAVIGATION PROPERTIES (3)

        // One User To Many House
        public int UserId { get; set; }
        public User User { get; set; }

        // One House To Many Location
        public List<Location> Locations { get; set; }

        // One House To Many Rooms?
        public List<Room>? Room { get; set; }

        #endregion

        #region CONSTRUCTORS

        public House()
        {
        }

        public House(HouseCreateDto houseCreateDto, int userId)
        {
            if (houseCreateDto.Indice == null) 
                throw new ArgumentNullException("houseCreateDto.Indice is null");

            Name = houseCreateDto.Name;
            Indice = houseCreateDto.Indice.Value;
            UserId = userId;
        }

        #endregion
    }
}
