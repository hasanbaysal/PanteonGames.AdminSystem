using FluentValidation;
using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteonGames.AdminSystem.Business.Extentions;
using PanteonGames.AdminSystem.Business.Services;
using PanteonGames.AdminSystem.Dto;
using PanteonGames.AdminSystem.Dto.TokenDto;
using PanteonGames.AdminSystem.Helper.ResponseStucture;

namespace PanteonGames.AdminSystem.Business.Managers
{
    public class AuthManager : IAuthService
    {
        private readonly IUow uow;
        private readonly IValidator<UserLoginDto> loginDtoValidator;
        private readonly ITokenService tokenService;
        public AuthManager(IUow uow, IValidator<UserLoginDto> loginDtoValidator, ITokenService tokenService)
        {
            this.uow = uow;
            this.loginDtoValidator = loginDtoValidator;
            this.tokenService = tokenService;
        }

        public async Task<IResponse<TokenResultDto>> Login(UserLoginDto dto)
        {
            var result = loginDtoValidator.Validate(dto);
            if (!result.IsValid)
                return new Response<TokenResultDto>(new TokenResultDto(), result.CustomErrorList());

            var data = await uow.
                    userRepository.
                    GetbyFilter(x => x.UserName == dto.UserName && x.Password == dto.Password);
            if (data != null)
            {
                var token = tokenService.GetToken(data.Id, data.UserName, data.Email);

                var tokenReposnse = new TokenResultDto()
                {
                    Token = token
                };
                return new Response<TokenResultDto>(ResponseType.Success, tokenReposnse);

            }
            return new Response<TokenResultDto>(ResponseType.Error, "pls control your username or password");


        }
    }
}
