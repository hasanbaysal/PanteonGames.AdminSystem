using PanteonGames.AdminSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteionGames.AdminSystem.DataAccess.Abstract
{
    public interface IUow
    {
       
        public IUserRepository userRepository { get; set; }
        IRepository<T> GetBaseRepository<T>() where T : BaseEntity;
        Task CommitAsync();

    }
}
