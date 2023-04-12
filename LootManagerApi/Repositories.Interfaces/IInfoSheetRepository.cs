using LootManagerApi.Dto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IInfoSheetRepository
    {
        Task<InfoSheetSummaryDto> CreateInfoSheetAsync(InfoSheetCreateDto infoSheetCreateDto, int userId);

    }
}
