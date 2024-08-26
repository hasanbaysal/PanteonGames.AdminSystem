using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PanteonGames.AdminSystem.Business.Managers;
using PanteonGames.AdminSystem.Business.Services;
using PanteonGames.AdminSystem.Business.ValidationRules.AppUserRules;
using PanteonGames.AdminSystem.Business.ValidationRules.GameConfigRules;
using PanteonGames.AdminSystem.Dto;
using PanteonGames.AdminSystem.Dto.GameConfigDto;
using System.Reflection;

namespace PanteonGames.AdminSystem.Business.DependencyResolver
{
    public static class DependenctExtention
    {
        public static void AddBusinessDependcies(this IServiceCollection services)
        {

            services.AddScoped<ITokenService, TokenManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IGameConfigService, GameConfigManager>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());



            services.AddTransient<IValidator<UserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<UserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<GameConfigCreateDto>, GameConfigCreateDtoValidator>();

        }
    }
}
