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
            return await context.Rooms.Where(r => r.Id == roomId).Select(r =>  r.HouseId).FirstAsync();
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
        /// Id required to find the room to be updated.
        /// Only non-null data will be modified.
        /// </summary>
        /// <param name="roomUpdateDto"></param>
        /// <returns>RoomDto</returns>
        /// <exception cref="Exception"></exception>
        public async Task<RoomDto> UpdateRoomAsync(RoomUpdateDto roomUpdateDto)
        {
            try
            {
                if (roomUpdateDto.Name == null && roomUpdateDto.Indice == null && roomUpdateDto.HouseId == null)
                    throw new Exception("No changes needed.");

                Room room = await context.Rooms.FirstAsync(e => e.Id == roomUpdateDto.Id);

                if (roomUpdateDto.Name != null)
                    room.Name = roomUpdateDto.Name;

                if (roomUpdateDto.Indice != null)
                    room.Indice = roomUpdateDto.Indice.Value;

                if (roomUpdateDto.HouseId != null)
                    room.HouseId = roomUpdateDto.HouseId.Value;

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

        public async Task<bool> IsOwnerOfTheRoomAsync(int userId, int roomId)
        {
            var roomList = await context.Houses
                    .Include(h => h.Rooms)
                    .Where(h => h.UserId == userId)
                    .SelectMany(h => h.Rooms)
                    .ToListAsync();

            var roomIdList = roomList.Select(r => r.Id).ToList();

            if (roomIdList.Any(i => i == roomId))
                return true;

            throw new Exception("This user cannot access this house.");
        }

        public async Task<bool>CheckRoomUpdateDtoAsync(RoomUpdateDto roomUpdateDto, int userId)
        {
            // Pour résoudre la méthode il faut passer par la Location //

            // Tableau gén : Un seul appel à la db doit pouvoir résoudre toutes les étapes de la méthode

            // Check User => Room

            // Check User => House

            // Check Id House Si nul Id current House

            // Check Indice Room; Si le même que le current c'est OK; Si Déjà utilisé : Erreur ; Si Nul : Auto Indice 

            throw new NotImplementedException();
        }

        #endregion
    }
}
