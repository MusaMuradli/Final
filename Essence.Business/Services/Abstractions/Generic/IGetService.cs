using Essence.Business.Abstractions.Dtos;
namespace Essence.Business.Services.Abstractions.Generic;

public interface IGetService<TGetDto>
    where TGetDto : IDto
{
    Task<TGetDto> GetAsync(int id);
    List<TGetDto> GetAll();
}
