using LootManagerApi.Entities.logistics;
using LootManagerApi.Entities;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class HouseBoard
    {
        public User User { get; set; }
        public House House { get; set; }
        public Room Room { get; set; }
        public Furniture Furniture { get; set; }
        public Shelf Shelf { get; set; }
        public Position Position { get; set; }
    }

}
