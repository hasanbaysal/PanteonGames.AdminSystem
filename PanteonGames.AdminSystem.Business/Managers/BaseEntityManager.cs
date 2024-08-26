using AutoMapper;
using FluentValidation;
using PanteionGames.AdminSystem.DataAccess.Abstract;
using PanteonGames.AdminSystem.Business.Extentions;
using PanteonGames.AdminSystem.Business.Services;
using PanteonGames.AdminSystem.Dto;
using PanteonGames.AdminSystem.Entity;
using PanteonGames.AdminSystem.Helper.ResponseStucture;

namespace PanteonGames.AdminSystem.Business.Managers
{
    public class BaseEntityManager<CreateDto, UpdateDto, ListDto, T> : IBaseEntityService<CreateDto, UpdateDto, ListDto, T>
      where CreateDto : class, ICreateDto, new()
      where UpdateDto : class, IUpdateDto, new()
      where ListDto : class, IListDto, new()
      where T : BaseEntity
    {

        private readonly IMapper mapper;
        private readonly IUow uow;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _UpdateDtoValidator;

        public BaseEntityManager(IMapper mapper, IUow uow, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator)
        {
            this.mapper = mapper;
            this.uow = uow;
            _createDtoValidator = createDtoValidator;
            _UpdateDtoValidator = updateDtoValidator;
        }

        public virtual async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (!result.IsValid)
                return new Response<CreateDto>(dto, result.CustomErrorList());

            var entity = mapper.Map<T>(dto);
            uow.GetBaseRepository<T>().Create(entity);
            await uow.CommitAsync();
            return new Response<CreateDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await uow.GetBaseRepository<T>().GetAllAsync();
            var converted = mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Success, converted);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {

            var data = await uow.GetBaseRepository<T>().GetbyFilter(x => x.Id == id);

            if (data == null)

                return new Response<IDto>(ResponseType.NotFound, $"{id} id data bulunamadı");

            var mappedData = mapper.Map<IDto>(data);

            return new Response<IDto>(ResponseType.Success, mappedData);
        }

        public async Task<IResponse> RemoveAsync(object id)
        {
            var data = await uow.GetBaseRepository<T>().FindAsync(id);
            if (data == null)

                return new Response(ResponseType.NotFound, $"{id} id data bulunamadı");

            uow.GetBaseRepository<T>().Remove(data);
            await uow.CommitAsync();

            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var validation = _UpdateDtoValidator.Validate(dto);
            if (!validation.IsValid)
                return new Response<UpdateDto>(dto, validation.CustomErrorList());

            var data = await uow.GetBaseRepository<T>().FindAsync(dto.Id);

            if (data == null)
                return new Response<UpdateDto>(ResponseType.NotFound, $"{dto.Id} id data bulunamadı ");


            var mappedData = mapper.Map<T>(dto);

            uow.GetBaseRepository<T>().Update(mappedData, data);
            await uow.CommitAsync();

            return new Response<UpdateDto>(ResponseType.Success, dto);
        }
    }
}
