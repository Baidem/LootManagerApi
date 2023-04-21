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

        #endregion

        #region CONSTRUCTOR

        public RoomRepository(LootManagerContext context, ILogger<UserRepository> logger)
        {
            this.context = context;
            this.logger = logger;
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


        #region UTILS

        public async Task<int> AutoIndice(int houseId)
        {
            var roomIndicelist = await context.Rooms.Where(r => r.HouseId == houseId).Select(r => r.Indice).ToListAsync();

            roomIndicelist.Sort();
            for (int i = 0; i < roomIndicelist.Count; i++)
            {
                if (i == 0 && roomIndicelist[i] > 1)
                    return 1;

                if (i == roomIndicelist.Count - 1 || roomIndicelist[i + 1] - roomIndicelist[i] > 1)
                    return roomIndicelist[i] + 1;
            }

            throw new Exception("An error occurred during the AutoIndice process.");
        }

        public async Task<bool> ThisIndexIsFreeAsync(int indice, int houseId)
        {
            var roomIndicelist = await context.Rooms.Where(r => r.HouseId == houseId).Select(r => r.Indice).OrderBy(i => i).ToListAsync();

            int left = 0;
            int right = roomIndicelist.Count - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (roomIndicelist[middle] == indice)
                {
                    throw new Exception("This indice is not free.");
                }

                if (roomIndicelist[middle] < indice)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return true;
        }

        public async Task<bool> IsARoomInTheHouseAsync(int houseId, int roomId)
        {
            if (await context.Rooms.AnyAsync(r => r.HouseId == houseId && r.Id == roomId))
                return true;

            throw new Exception("This room is not part of the house.");
        }

        #endregion


    }
}
