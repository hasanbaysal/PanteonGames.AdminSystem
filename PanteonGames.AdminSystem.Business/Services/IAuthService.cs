using PanteonGames.AdminSystem.Dto;
using PanteonGames.AdminSystem.Dto.TokenDto;
using PanteonGames.AdminSystem.Helper.ResponseStucture;

namespace PanteonGames.AdminSystem.Business.Services
{
    public interface IAuthService
    {
        Task<IResponse<TokenResultDto>> Login(UserLoginDto dto);
    }
}
