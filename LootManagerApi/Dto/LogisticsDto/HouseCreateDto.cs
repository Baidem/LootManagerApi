using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace LootManagerApi.Dto.LogisticsDto
{
    public class HouseCreateDto
    {
        [Required] public string Name { get; set; }
        public int? Indice { get; set; }

        public HouseCreateDto()
        {
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
