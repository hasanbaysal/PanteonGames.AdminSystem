using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteionGames.AdminSystem.DataAccess.Concrete;
using PanteionGames.AdminSystem.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteionGames.AdminSystem.DataAccess.DependencyResolver
{
    public static class DependencyExtention
    {
        public static void AddDataAccessDependencies(this IServiceCollection services,string cs)
        {
            services.AddScoped<IUow, Uow>();

            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseMySQL(cs);
            });

        }
    }
}
