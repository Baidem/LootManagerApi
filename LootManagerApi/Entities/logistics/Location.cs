using System.Reflection;
using System.Text;

namespace LootManagerApi.Entities.logistics
{
    public class Location
    {
        #region PROPERTIES

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region NAVIGATION PROPERTIES (8)

        // One Location? To Many Element?
        public List<Element>? Elements { get; set; }

        // One House? To One Location?
        public House? House { get; set; }

        // One Room? To One Location?
        public Room? Room { get; set; }

        // One Furniture? To One Location?
        public Furniture? Furniture { get; set; }

        // One Shelf? To One Location
        public Shelf? Shelf { get; set; }

        // One Position? To One Location?
        public Position? Position { get; set; }

        // One User To Many Location
        public int? UserId { get; set; }
        public User? User { get; set; }

        // One DefaultLocation? To One Location
        public DefaultLocation? DefaultLocation { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Location()
        {
        }

        #endregion

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }
    }
}
