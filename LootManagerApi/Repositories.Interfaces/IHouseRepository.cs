using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IHouseRepository
    {
        Task<HouseDto> CreateHouseAsync(HouseCreateDto houseCreateDto, int UserId); 
    }
}
