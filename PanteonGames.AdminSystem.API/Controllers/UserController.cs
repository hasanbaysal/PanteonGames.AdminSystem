using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PanteonGames.AdminSystem.API.Extention;
using PanteonGames.AdminSystem.Business.Services;
using PanteonGames.AdminSystem.Dto;

namespace PanteonGames.AdminSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;

        public UserController(IAuthService authService, IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var result = await authService.Login(dto);

            return this.Response(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Regiser(UserCreateDto dto)
        {
            var result = await userService.CreateAsync(dto);

            return this.Response(result);
        }

    }
}
