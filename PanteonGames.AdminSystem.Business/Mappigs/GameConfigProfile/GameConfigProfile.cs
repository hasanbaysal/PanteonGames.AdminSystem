using AutoMapper;
using PanteonGames.AdminSystem.Dto.GameConfigDto;
using PanteonGames.AdminSystem.Entity.Entities;

namespace PanteonGames.AdminSystem.Business.Mappigs.GameConfigProfile
{
    public class GameConfigProfile : Profile
    {

        public GameConfigProfile()
        {
            CreateMap<GameConfigCreateDto, GameConfig>();
        }
    }
}
