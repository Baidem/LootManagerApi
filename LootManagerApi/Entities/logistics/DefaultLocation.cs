namespace LootManagerApi.Entities.logistics
{
    public class DefaultLocation
    {
        public int Id { get; set; }

        // NAVIGATION PROPERTIES

        // One DefaultLocation To One User
        public int UserId { get; set; }
        public User User { get; set; }

        // One DefaultLocation To One User
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
