using LootManagerApi.Dto;
using LootManagerApi.Entities;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IElementRepository
    {
        ElementCreateDto CreateElement(ElementCreateDto elementCreateDto, int userId);
        Task<List<string>> GetElementsAsync(int userId);
        Task<Element> GetElementAsync(int elementId, int userId);
        Task<Element> UpdateElementAsync(ElementUpdateDto elementUpdateDto, int userId);
        Task<Element> DeleteElementAsync(int elementId, int userId);
    }
}
