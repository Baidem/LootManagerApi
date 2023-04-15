using LootManagerApi.Entities;

namespace LootManagerApi.Dto
{
    public class InfosheetIdAndDesignation
    {
        public int Id { get; set; }
        public string? Designation { get; set; }

        public InfosheetIdAndDesignation()
        {
        }

        public InfosheetIdAndDesignation(InfoSheet infoSheet)
        {
            Id = infoSheet.Id;
            Designation = infoSheet.Designation;
        }
    }

}
