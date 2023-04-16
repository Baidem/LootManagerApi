using LootManagerApi.Dto;
using LootManagerApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IElementRepository
    {
        Task<ElementDto> CreateElementAsync(ElementCreateDto elementCreateDto, int userId);
        Task<List<ElementDto>> GetElementsAsync(int userId);
        Task<ElementDto> GetElementAsync(int elementId);
        Task<ElementDto> UpdateElementAsync(ElementUpdateDto elementUpdateDto);
        Task<Element> DeleteElementAsync(int elementId, int userId);
        Task<bool> IsOwnerOfTheElementAsync(int userId, int elementId);
    }
}
