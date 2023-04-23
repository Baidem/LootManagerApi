namespace LootManagerApi.Entities.logistics
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public int NumberOfShelves { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // NAVIGATION PROPERTIES (4)

        // One Furniture? To Many Location
        public List<Location> Locations { get; set; }

        // One Room To Many Furniture?
        public int RoomId { get; set; }
        public Room Room { get; set; }

        // One Furniture To Many Shelf?
        public List<Shelf>? Shelves { get; set; }

        //// One User To Many Furniture
        //public int UserId { get; set; }
        //public User User { get; set; }
    }
}
