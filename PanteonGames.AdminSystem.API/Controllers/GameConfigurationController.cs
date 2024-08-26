using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanteonGames.AdminSystem.API.Extention;
using PanteonGames.AdminSystem.Business.Services;
using PanteonGames.AdminSystem.Dto.GameConfigDto;
using PanteonGames.AdminSystem.Entity.Entities;
using System.Security.Claims;

namespace PanteonGames.AdminSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class GameConfigurationController : ControllerBase
    {

        private readonly IGameConfigService _gameConfigService;

        public GameConfigurationController(IGameConfigService gameConfigService)
        {
            _gameConfigService = gameConfigService;
        }
        [Authorize]
        [HttpGet("GetAllConfig")]   
        public async Task<IActionResult> GetConfig()
        {
            var userId = Convert.ToInt32( User.FindFirstValue("UserId"));
            var data = await _gameConfigService.GetAllGameConfig(userId);
            return this.Response<List<GameConfig>>(data);
        }

        [Authorize]
        [HttpPost("CreateConfig")]
        public async Task<IActionResult> CreateConfig(GameConfigCreateDto dto)
        {
            var userId = Convert.ToInt32(User.FindFirstValue("UserId"));
            var data = await _gameConfigService.CreateGameConfig(dto,userId);
            return this.Response<GameConfigCreateDto>(data);
        }



    }
}
