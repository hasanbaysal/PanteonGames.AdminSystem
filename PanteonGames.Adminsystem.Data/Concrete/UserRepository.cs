using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteionGames.AdminSystem.DataAccess.Contexts;
using PanteonGames.AdminSystem.Entity.Entities;

namespace PanteionGames.AdminSystem.DataAccess.Concrete
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }


    }
}
