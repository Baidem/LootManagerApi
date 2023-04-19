namespace LootManagerApi.Entities.logistics
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }

        // NAVIGATION PROPERTIES (3)

        // One User To Many House
        public int UserId { get; set; }
        public User User { get; set; }

        // One House To Many Location
        public List<Location> Locations { get; set; }

        // One House To Many Rooms?
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
