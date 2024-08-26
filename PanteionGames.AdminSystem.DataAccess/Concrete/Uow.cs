using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteionGames.AdminSystem.DataAccess.Contexts;
using PanteonGames.AdminSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteionGames.AdminSystem.DataAccess.Concrete
{
    public class Uow : IUow
    {
        private readonly AppDbContext appDbContext;
        
        public IUserRepository userRepository { get; set; }
       

        public Uow(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            
            userRepository = new  UserRepository(appDbContext);
         
        }

        public async Task CommitAsync()
        {
          await appDbContext.SaveChangesAsync();
        }

        public IRepository<T> GetBaseRepository<T>() where  T: BaseEntity
        {
            return new Repository<T>(appDbContext);
        }
     
    }
}
