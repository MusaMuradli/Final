using Essence.Business.Dtos.UIDtos;

namespace Essence.Business.UIServices.Abstractions;

public interface IHomeService
{
    Task<HomeDto> GetHomeDtoAsync();
}
