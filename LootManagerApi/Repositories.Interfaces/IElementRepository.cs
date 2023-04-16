using LootManagerApi.Dto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IElementRepository
    {
        Task<ElementDto> CreateElementAsync(ElementCreateDto elementCreateDto, int userId);
        Task<List<ElementDto>> GetElementsAsync(int userId);
        Task<ElementDto> GetElementAsync(int elementId);
        Task<ElementDto> UpdateElementAsync(ElementUpdateDto elementUpdateDto);
        Task<ElementDto> DeleteElementAsync(int elementId);
        Task<bool> IsOwnerOfTheElementAsync(int userId, int elementId);
        Task<bool> IsElementExistAsync(int elementId);
    }
}
