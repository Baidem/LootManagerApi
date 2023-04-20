using LootManagerApi.Dto;
using LootManagerApi.Dto.LogisticsDto;
using LootManagerApi.Entities;
using LootManagerApi.Entities.logistics;
using LootManagerApi.Repositories.Interfaces;

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

    }
}
