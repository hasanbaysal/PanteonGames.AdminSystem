using PanteionGames.AdminSystem.DataAccess.Concrete;
using PanteonGames.AdminSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteionGames.AdminSystem.DataAccess.Abstract
{
    public interface IUserRepository :IRepository<AppUser>
    {
    }
}
