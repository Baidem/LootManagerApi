using LootManagerApi.Dto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IElementRepository
    {
        // CREATE
        Task<ElementDto> CreateElementAsync(ElementCreateDto elementCreateDto, int userId);
        
        // READ
        Task<List<ElementDto>> GetElementsAsync(int userId);
        Task<ElementDto> GetElementAsync(int elementId);
        
        // UPDATE
        Task<ElementDto> UpdateElementAsync(ElementUpdateDto elementUpdateDto);
        
        // DELETE
        Task<ElementDto> DeleteElementAsync(int elementId);
        
        // UTILS
        Task<bool> IsOwnerOfTheElementAsync(int userId, int elementId);
        Task<bool> IsElementExistAsync(int elementId);
    }
}
