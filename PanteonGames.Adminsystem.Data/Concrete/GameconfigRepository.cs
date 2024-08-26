using PanteionGames.AdminSystem.DataAccess.Contexts;
using PanteonGames.Adminsystem.Data.Abstract;
using PanteonGames.AdminSystem.Entity.Entities;

namespace PanteionGames.AdminSystem.DataAccess.Concrete
{
    public class GameconfigRepository : BaseMongoRepository<GameConfig>, IGameConfigRepository
    {


        public GameconfigRepository(MongoDbContext mongoDbContext, string name) : base(mongoDbContext, name)
        {

        }
    }
}
