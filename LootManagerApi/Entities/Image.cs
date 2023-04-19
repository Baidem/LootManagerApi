namespace LootManagerApi.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Caption { get; set; }

        // NAVIGATION PROPERTIES (2)

        // Many Element? To Many Images?
        public List<Element>? Elements { get; set; }


        public List<InfoSheet>? InfoSheets { get; set; }
    }
}
