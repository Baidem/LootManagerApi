using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        // CREATE
        Task<RoomDto> CreateRoomAsync(RoomCreateDto roomCreateDto);
        Task<RoomDto> CreateTheDefaultRoomAsync(int userId);

        // READ
        Task<List<RoomDto>> GetRoomsByUserIdAsync(int userId);
        Task<List<RoomDto>> GetRoomsByHouseIdAsync(int houseId);
        Task<RoomDto> GetRoomAsync(int roomId);
        Task<int> GetHouseIdOfTheRoomAsync(int roomId);

        // UPDATE
        Task<RoomDto> UpdateRoomAsync(RoomUpdateDto roomUpdateDto);


        // UTILS
        Task<int> AutoIndice(int userId);
        Task<bool> ThisIndexIsFreeAsync(int indice, int houseId);
        Task<bool> IsARoomInTheHouseAsync(int roomId, int houseId);
        Task<bool> IsOwnerOfTheRoomAsync(int userId, int roomId);
        Task<bool> CheckRoomUpdateDtoAsync(RoomUpdateDto roomUpdateDto, int userId);





    }
}
