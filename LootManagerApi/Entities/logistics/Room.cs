namespace LootManagerApi.Entities.logistics
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // NAVIGATION PROPERTIES (3)

        // One Room? To Many Location
        public List<Location> Locations { get; set; }

        // One House To Many Room?
        public int HouseId { get; set; }
        public House House { get; set; }

        // One Room To Many Furniture?
        public List<Furniture>? Furnitures { get; set; }
    }
}
