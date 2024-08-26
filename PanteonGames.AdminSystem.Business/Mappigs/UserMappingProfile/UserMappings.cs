using AutoMapper;
using PanteonGames.AdminSystem.Dto;
using PanteonGames.AdminSystem.Dto.UserDto;
using PanteonGames.AdminSystem.Entity.Entities;

namespace PanteonGames.AdminSystem.Business.Mappigs.UserMappingProfile
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<UserUpdateDto, AppUser>();
            CreateMap<AppUser, UserListDto>();
            CreateMap<UserCreateDto, AppUser>();
        }
    }
}
