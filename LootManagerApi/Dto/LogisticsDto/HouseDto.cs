using LootManagerApi.Entities.logistics;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class HouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Indice { get; set; }
        public int UserId { get; set; }

        public HouseDto()
        {
        }

        public HouseDto(House house)
        {
            Id = house.Id;
            Name = house.Name;
            Indice = house.Indice ;
            UserId = house.UserId;
        }

        #region METHODS

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                sb.AppendLine($"{prop.Name}: {prop.GetValue(this)}");
            }
            return sb.ToString();
        }

        #endregion

    }
}
