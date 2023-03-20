using LootManagerApi.Dto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IElementRepository
    {
        ElementCreateDto CreateElement(ElementCreateDto elementCreateDto, int userId);
    }
}
