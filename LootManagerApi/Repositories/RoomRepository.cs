using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities.logistics;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        #region DECLARATION

        LootManagerContext context;
        ILogger<UserRepository> logger;
        IHouseRepository houseRepository;

        #endregion

        #region CONSTRUCTOR

        public RoomRepository(LootManagerContext context, ILogger<UserRepository> logger, IHouseRepository houseRepository)
        {
            this.context = context;
            this.logger = logger;
            this.houseRepository = houseRepository;
        }

        #endregion

        #region CREATE

        public async Task<RoomDto> CreateRoomAsync(RoomCreateDto roomCreateDto)
        {
            try
            {
                var room = new Room(roomCreateDto);

                await context.Rooms.AddAsync(room);

                await context.SaveChangesAsync();

                return new RoomDto(room);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the Room : {ex.Message}");
            }
        }

        public async Task<RoomDto> CreateTheDefaultRoomAsync(int houseId)
        {
            try
            {
                var roomCreateDto = new RoomCreateDto
                {
                    Name = "My hub",
                    Indice = 1,
                    HouseId = houseId
                };

                return await CreateRoomAsync(roomCreateDto);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while creating the default Room : {ex.Message}");
            }
        }

        #endregion

        #region READ

        public async Task<List<RoomDto>> GetRoomsByUserIdAsync(int userId)
        {
            var roomList = await context.Houses
                    .Include(h => h.Rooms)
                    .Where(h => h.UserId == userId)
                    .SelectMany(h => h.Rooms)
                    .ToListAsync();

            if (roomList.Any())
                return roomList.Select(r => new RoomDto(r)).ToList();

            throw new Exception($"You have no room in your houses.");
        }

        public async Task<List<RoomDto>> GetRoomsByHouseIdAsync(int houseId)
        {

            var roomList = await context.Houses
                    .Include(h => h.Rooms)
                    .Where(h => h.Id == houseId)
                    .SelectMany(h => h.Rooms)
                    .ToListAsync();

            if (roomList.Any())
                return roomList.Select(r => new RoomDto(r)).ToList();

            throw new Exception($"You have no room in your house.");
        }

        public async Task<RoomDto> GetRoomAsync(int roomId)
        {
            return await context.Rooms.Where(r => r.Id == roomId).Select(r => new RoomDto(r)).FirstAsync();
        }

        public async Task<int> GetHouseIdOfTheRoomAsync(int roomId)
        {
            return await context.Rooms.Where(r => r.Id == roomId).Select(r => r.HouseId).FirstAsync();
        }

        private async Task<int> GetOwnerIdOfTheRoomAsync(int roomId)
        {
            var userId = await context.Rooms
                .Where(r => r.Id == roomId)
                .Join(context.Houses, r => r.HouseId, h => h.Id, (r, h) => h.UserId)
                .FirstOrDefaultAsync();

            return userId;
        }

        #endregion

        #region UPDATE

        /// <summary>
        /// Updating an Room by an RoomUpdateDto.
        /// </summary>
        /// <param name="roomUpdateDto"></param>
        /// <returns>RoomDto</returns>
        /// <exception cref="Exception"></exception>
        public async Task<RoomDto> UpdateRoomByDtoAsync(RoomUpdateDto roomUpdateDto)
        {
            try
            {
                Room room = await context.Rooms.FirstAsync(e => e.Id == roomUpdateDto.Id);
                
                room.Name = roomUpdateDto.Name;

                if (roomUpdateDto.HouseId != room.House.Id)
                {
                    room.HouseId = roomUpdateDto.HouseId;

                    await CheckIfTheRoomIndiceIsFreeThisHouseAsync(room.HouseId, roomUpdateDto.Indice);
                }
                else if (roomUpdateDto.HouseId == room.House.Id)
                {
                    if (roomUpdateDto.Indice != room.Indice)
                        await CheckIfTheRoomIndiceIsFreeThisHouseAsync(room.HouseId, roomUpdateDto.Indice);
                }

                room.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();

                return new RoomDto(room);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the room. {ex.Message}", ex);
            }
        }

        #endregion

        #region DELETE
        public async Task<RoomDto> DeleteRoomAsync(int roomId)
        {
            var room = await context.Rooms.FirstAsync(r => r.Id == roomId);

            context.Rooms.Remove(room);

            await context.SaveChangesAsync();

            return new RoomDto(room);
        }

        #endregion

        #region UTILS

        public async Task<int> AutoIndice(int houseId)
        {
            var maxIndice = await context.Rooms
                        .Where(r => r.HouseId == houseId)
                        .Select(r => r.Indice)
                        .DefaultIfEmpty(0)
                        .MaxAsync();

            return maxIndice + 1;

            throw new Exception("An error occurred during the AutoIndice process.");
        }

        public async Task<bool> CheckIfTheRoomIndiceIsFreeThisHouseAsync(int indice, int houseId)
        {
            if (!await context.Rooms.AnyAsync(r => r.HouseId == houseId && r.Indice == indice))
                return true;
            throw new Exception("The index does not free.");
        }

        public async Task<bool> CheckTheOwnerOfTheRoomAsync(int userId, int roomId)
        {
            if (await context.Rooms.AnyAsync(r => r.UserId == userId && r.Id == roomId))
                return true;

            throw new Exception("This user cannot access this house.");
        }

        #endregion
    }
}
