using LootManagerApi.Dto.LogisticsDto;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        // CREATE
        Task<RoomDto> CreateRoomAsync(RoomCreateDto roomCreateDto);
        Task<RoomDto> CreateTheDefaultRoomAsync(int userId);


        // UTILS
        Task<int> AutoIndice(int userId);
        Task<bool> ThisIndexIsFreeAsync(int indice, int houseId);

        Task<bool> IsARoomInTheHouseAsync(int roomId, int houseId);

    }
}
