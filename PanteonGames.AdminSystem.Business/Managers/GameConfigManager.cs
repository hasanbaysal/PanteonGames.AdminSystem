using AutoMapper;
using FluentValidation;
using MongoDB.Driver;
using PanteonGames.Adminsystem.Data.Abstract;
using PanteonGames.AdminSystem.Business.Extentions;
using PanteonGames.AdminSystem.Business.Services;
using PanteonGames.AdminSystem.Dto.GameConfigDto;
using PanteonGames.AdminSystem.Entity.Entities;
using PanteonGames.AdminSystem.Helper.ResponseStucture;

namespace PanteonGames.AdminSystem.Business.Managers
{
    public class GameConfigManager : IGameConfigService
    {
        private readonly IGameConfigRepository gameConfigRepository;
        private readonly IMapper mapper;
        private readonly IValidator<GameConfigCreateDto> _cretaDtoValidator;
        public GameConfigManager(IGameConfigRepository gameConfigRepository, IMapper mapper, IValidator<GameConfigCreateDto> cretaDtoValidator)
        {
            this.gameConfigRepository = gameConfigRepository;
            this.mapper = mapper;
            _cretaDtoValidator = cretaDtoValidator;
        }

        public async Task<Response<GameConfigCreateDto>> CreateGameConfig(GameConfigCreateDto gameConfig,int userID)
        {
            gameConfig.UserId = userID;
            var result = _cretaDtoValidator.Validate(gameConfig);

            if (!result.IsValid)
            {
                return new Response<GameConfigCreateDto>(gameConfig, result.CustomErrorList());
            }
            var mappedData = mapper.Map<GameConfig>(gameConfig);
            await gameConfigRepository.CreateAsync(mappedData);

            return new Response<GameConfigCreateDto>(ResponseType.Success, gameConfig);
        }

        
        public async Task<Response<List<GameConfig>>> GetAllGameConfig(int userId)
        {

            
            var filter = Builders<GameConfig>.Filter.Eq(gc => gc.UserId, userId);
            var data = await gameConfigRepository.GetByFilterAsync(filter);  
            return new Response<List<GameConfig>>(ResponseType.Success, data);
        }
    }
}
