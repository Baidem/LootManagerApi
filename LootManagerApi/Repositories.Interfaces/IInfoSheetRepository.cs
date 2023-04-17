using LootManagerApi.Dto;
using LootManagerApi.Entities;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IInfoSheetRepository
    {
        //CREATE
        Task<InfoSheetSummaryDto> CreateInfoSheetAsync(InfoSheetCreateDto infoSheetCreateDto, int userId);
        
        // READ
        Task<List<InfosheetIdAndDesignation>> GetAllInfoSheetByUserIdAsync(int userId);
        Task<InfoSheet> GetInfoSheetByIdAsync(int infoSheetId);
        
        // UPDATE
        Task<InfoSheet> UpdateInfoSheetAsync(InfoSheetUpdateDto infoSheetUpdateDto);
        
        // DELETE
        Task<string> DeleteInfoSheetAsync(int infoSheetId);
        
        // UTILS
        Task<bool> IsInfoSheetExistAsync(int infoSheetId);
        Task<bool> IsCurrentUserTheOwnerOfInfoSheetAsync(UserAuthDto userAuthDto, int infoSheetId);
    }
}
