using PanteonGames.AdminSystem.Entity;

namespace PanteionGames.AdminSystem.DataAccess.Abstract
{
    public interface IUow
    {

        public IUserRepository userRepository { get; set; }
        IRepository<T> GetBaseRepository<T>() where T : BaseEntity;
        Task CommitAsync();

    }
}
