using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities.logistics;

namespace LootManagerApi.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        // CREATE
        Task<RoomDto> CreateRoomByDtoAsync(RoomCreateDto roomCreateDto, LocationDto locationDto);

        // READ
        Task<List<RoomDto>> GetRoomsByUserIdAsync(int userId);
        Task<List<RoomDto>> GetRoomsByHouseIdAsync(int houseId);
        Task<RoomDto> GetRoomAsync(int roomId);
        Task<int> GetHouseIdOfTheRoomAsync(int roomId);

        // UPDATE
        Task<RoomDto> UpdateRoomByDtoAsync(RoomUpdateDto roomUpdateDto);

        // DELETE
        Task<RoomDto> DeleteRoomAsync(int roomId);

        // UTILS
        Task<int> AutoIndiceRoom_LastAddOne(int houseId);
        Task<bool> CheckIfTheRoomIndiceIsFreeThisHouseAsync(int indice, int houseId);
        Task<bool> CheckTheOwnerOfTheRoomAsync(int userId, int roomId);
        Task<RoomCreateDto> CheckIndiceFreeOrUpdateDefaultIndice(RoomCreateDto roomcreateDto);

    }
}
