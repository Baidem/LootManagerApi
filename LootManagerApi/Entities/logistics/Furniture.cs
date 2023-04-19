namespace LootManagerApi.Entities.logistics
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public int NumberOfLevels { get; set; }

        // NAVIGATION PROPERTIES (3)

        // One Furniture? To Many Location
        public List<Location> Locations { get; set; }

        // One Room To Many Furniture?
        public Room Room { get; set; }
        public int RoomId { get; set; }

        // One Furniture To Many Shelf?
        public List<Shelf>? Shelves { get; set; }
    }
}
