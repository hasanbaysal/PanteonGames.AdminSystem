using PanteonGames.AdminSystem.Dto;
using PanteonGames.AdminSystem.Dto.UserDto;
using PanteonGames.AdminSystem.Entity.Entities;

namespace PanteonGames.AdminSystem.Business.Services
{
    public interface IUserService : IBaseEntityService<UserCreateDto, UserUpdateDto, UserListDto, AppUser>
    {

    }
}
