using LootManagerApi.Dto;
using LootManagerApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IInfoSheetRepository
    {
        Task<InfoSheetSummaryDto> CreateInfoSheetAsync(InfoSheetCreateDto infoSheetCreateDto, int userId);
        Task<List<InfosheetIdAndDesignation>> GetAllInfoSheetByUserIdAsync(int userId);
        Task<InfoSheet> GetInfoSheetByIdAsync(int infoSheetId);
        Task<bool> IsInfoSheetExistAsync(int infoSheetId);
        Task<bool> IsCurrentUserTheOwnerOfInfoSheetAsync(UserAuthDto userAuthDto, int infoSheetId);
        Task<InfoSheet> UpdateInfoSheetAsync(InfoSheetUpdateDto infoSheetUpdateDto);
        Task<string> DeleteInfoSheetAsync(int infoSheetId);
    }
}
