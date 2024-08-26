using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteionGames.AdminSystem.DataAccess.Concrete;
using PanteionGames.AdminSystem.DataAccess.Contexts;
using PanteonGames.Adminsystem.Data.Abstract;
using PanteonGames.AdminSystem.Helper.Options;

namespace PanteionGames.AdminSystem.DataAccess.DependencyResolver
{
    public static class DependencyExtention
    {
        public static void AddDataAccessDependencies(this IServiceCollection services, string cs)
        {
            services.AddScoped<IUow, Uow>();

            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseMySQL(cs);
            });
            services.AddSingleton<MongoDbContext>();
            //services.AddScoped<IGameConfigRepository,GameconfigRepository>();
            services.AddScoped<IGameConfigRepository>(x =>
            {
                var cName = x.GetRequiredService<IOptions<MongoDbConfigOption>>().Value.CollectionName;
                var mongoDbContext = x.GetRequiredService<MongoDbContext>();

                return new GameconfigRepository(mongoDbContext, cName);
            });

        }
    }
}
