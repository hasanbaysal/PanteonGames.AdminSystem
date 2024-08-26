using PanteonGames.AdminSystem.Dto;
using PanteonGames.AdminSystem.Entity;
using PanteonGames.AdminSystem.Helper.ResponseStucture;

namespace PanteonGames.AdminSystem.Business.Services
{
    public interface IBaseEntityService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, ICreateDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IListDto, new()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse> RemoveAsync(object id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
    }
}
