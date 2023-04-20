using LootManagerApi.Dto.LogisticsDto;
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

        public Task<HouseDto> CreateHouseAsync(HouseCreateDto houseCreateDto, int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
