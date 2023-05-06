using LootManagerApi.Entities.logistics;
using LootManagerApi.Entities;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class HouseBoard
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = "N/A";
        public int HouseID { get; set; }
        public string HouseName { get; set; } = "N/A";
        public int HouseIndice { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = "N/A";

        public Furniture Furniture { get; set; }
        public Shelf Shelf { get; set; }
        public Position Position { get; set; }
    }

}
