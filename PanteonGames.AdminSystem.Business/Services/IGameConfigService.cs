using PanteonGames.AdminSystem.Dto.GameConfigDto;
using PanteonGames.AdminSystem.Entity.Entities;
using PanteonGames.AdminSystem.Helper.ResponseStucture;

namespace PanteonGames.AdminSystem.Business.Services
{
    public interface IGameConfigService
    {
        Task<Response<GameConfigCreateDto>> CreateGameConfig(GameConfigCreateDto gameConfig, int userID);
        Task<Response<List<GameConfig>>> GetAllGameConfig(int userId);


    }
}
