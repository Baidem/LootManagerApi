using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities;
using LootManagerApi.Entities.logistics;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LootManagerApi.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        #region DECLARATION

        LootManagerContext context;
        ILogger<UserRepository> logger;

        #endregion

        #region CONSTRUCTOR

        public HouseRepository(LootManagerContext context, ILogger<UserRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        #endregion

        #region CREATE

        public async Task<HouseDto> CreateHouseAsync(HouseCreateDto houseCreateDto, int UserId)
        {
            try
            {
                House house = new House(houseCreateDto, UserId);

                await context.Houses.AddAsync(house);

                await context.SaveChangesAsync();

                return new HouseDto(house);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the House : {ex.Message}");
            }
        }

        public async Task<HouseDto> CreateTheDefaultHouseAsync(int userId)
        {
            try
            {
                var houseCreateDto = new HouseCreateDto
                {
                    Name = "My house",
                    Indice = 1
                };

                return await CreateHouseAsync(houseCreateDto, userId);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while creating the default House : {ex.Message}");
            }
        }

        #endregion

        #region READ

        public async Task<List<HouseDto>> GetHousesAsync(int userId)
        {
            var houseDtos = await context.Houses.Where(e => e.UserId == userId).Select(e => new HouseDto(e)).ToListAsync();

            if (houseDtos.Any())
                return houseDtos;

            throw new Exception($"You have zero houses in your collection actually.");
        }

        public async Task<HouseDto> GetHouseAsync(int houseId)
        {
            var houseDtos = await context.Houses.Where(e => e.Id == houseId).Select(e => new HouseDto(e)).FirstOrDefaultAsync();

            if (houseDtos != null)
                return houseDtos;

            throw new Exception($"House was not found.");
        }

        #endregion

        #region UPDATE

        /// <summary>
        /// Asynchronous method of updating an House by an HouseUpdateDto.
        /// Id required to find the house to be updated.
        /// Only non-null data will be modified.
        /// </summary>
        /// <param name="houseUpdateDto"></param>
        /// <returns>HouseDto</returns>
        /// <exception cref="Exception"></exception>
        public async Task<HouseDto> UpdateHouseAsync(HouseUpdateDto houseUpdateDto)
        {
            try
            {
                if (houseUpdateDto.Name == null && houseUpdateDto.Indice == null)
                    throw new Exception("No changes needed.");

                House house = await context.Houses.FirstAsync(e => e.Id == houseUpdateDto.Id);

                if (houseUpdateDto.Name != null)
                    house.Name = houseUpdateDto.Name;

                if (houseUpdateDto.Indice != null)
                    house.Indice = houseUpdateDto.Indice.Value;

                //house.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();

                return new HouseDto(house);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the house. {ex.Message}", ex);
            }
        }

        #endregion

        #region DELETE

        public async Task<HouseDto> DeleteHouseAsync(int houseId)
        {
            try
            {
                var house = await context.Houses.FirstAsync(e => e.Id == houseId);

                context.Houses.Remove(house);

                await context.SaveChangesAsync();

                return new HouseDto(house);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the house. {ex.Message}", ex);
            }
        }

        #endregion

        #region UTILS

        public async Task<int> AutoIndice(int userId)
        {
            var houseIndicelist = await context.Houses.Where(h => h.UserId == userId).Select(h => h.Indice).ToListAsync();

            houseIndicelist.Sort();
            for (int i = 0; i < houseIndicelist.Count; i++)
            {
                if (i == 0 && houseIndicelist[i] > 1)
                    return 1;

                if (i == houseIndicelist.Count - 1 || houseIndicelist[i + 1] - houseIndicelist[i] > 1)
                    return houseIndicelist[i] + 1;
            }

            throw new Exception("An error occurred during the AutoIndice process.");
        }

        public async Task<bool> ThisIndexIsFreeAsync(int indice, int userId)
        {
            var houseIndicelist = await context.Houses.Where(h => h.UserId == userId).Select(h => h.Indice).OrderBy(i => i).ToListAsync();

            int left = 0;
            int right = houseIndicelist.Count - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (houseIndicelist[middle] == indice)
                {
                    throw new Exception("This indice is not free.");
                }

                if (houseIndicelist[middle] < indice)
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

        public async Task<bool> IsOwnerOfTheHouseAsync(int userId, int houseId)
        {
            if (await context.Houses.AnyAsync(e => e.UserId == userId && e.Id == houseId))
                return true;

            throw new Exception("This user cannot access this house.");
        }

        public async Task<bool> IsHouseExistAsync(int houseId)
        {
            if (await context.Houses.AnyAsync(e => e.Id == houseId))
                return true;

            throw new Exception("This house does not exist in the database.");
        }

        #endregion
    }
}
