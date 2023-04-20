using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IHouseRepository
    {
        Task<HouseDto> CreateHouseAsync(HouseCreateDto houseCreateDto, int UserId);
        Task<HouseDto> CreateTheDefaultHouseAsync(int userId);
        Task<int> AutoIndice(int userId);
        Task<bool> ThisIndexIsFreeAsync(int indice, int userId);
    }
}
