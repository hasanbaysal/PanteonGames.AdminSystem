using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteonGames.AdminSystem.Business.Extentions;
using PanteonGames.AdminSystem.Business.Services;
using PanteonGames.AdminSystem.Dto;
using PanteonGames.AdminSystem.Dto.UserDto;
using PanteonGames.AdminSystem.Entity.Entities;
using PanteonGames.AdminSystem.Helper.ResponseStucture;

namespace PanteonGames.AdminSystem.Business.Managers
{
    public class UserManager : BaseEntityManager<UserCreateDto, UserUpdateDto, UserListDto, AppUser>, IUserService
    {

        private readonly IUow uow;
        private readonly IMapper mapper;

        private readonly IValidator<UserCreateDto> _createDtoValidator;
        private readonly IValidator<UserUpdateDto> _UpdateDtoValidator;

        public UserManager(IMapper mapper, IUow uow, IValidator<UserCreateDto> createValidator, IValidator<UserUpdateDto> updateValidator)
            : base(mapper, uow, createValidator, updateValidator)
        {
            _createDtoValidator = createValidator;
            _UpdateDtoValidator = updateValidator;
            this.uow = uow;
            this.mapper = mapper;
        }
        public override async Task<IResponse<UserCreateDto>> CreateAsync(UserCreateDto dto)
        {


            var result = _createDtoValidator.Validate(dto);
            if (!result.IsValid)
                return new Response<UserCreateDto>(dto, result.CustomErrorList());

            //email - username control !
            //index var zaten
            var userNameResult = await uow.userRepository
                .GetQueryable()
                .AsNoTracking()
                .Where(x => x.UserName == dto.UserName)
                .ToListAsync();
            if (userNameResult.Count > 0)
                return new Response<UserCreateDto>(ResponseType.Conflict, $"{dto.UserName} already exists");

            var emailResult = await uow.userRepository
                .GetQueryable()
                .AsNoTracking()
                .Where(x => x.Email == dto.Email)
                .ToListAsync();

            if (emailResult.Count > 0)
                return new Response<UserCreateDto>(ResponseType.Conflict, "this email is already registered");


            return (await base.CreateAsync(dto));
        }


    }
}
