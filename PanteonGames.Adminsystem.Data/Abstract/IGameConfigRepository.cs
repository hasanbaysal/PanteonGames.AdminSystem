using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteonGames.AdminSystem.Entity.Entities;

namespace PanteonGames.Adminsystem.Data.Abstract
{
    public interface IGameConfigRepository : IMongoRepository<GameConfig>
    {
    }
}
