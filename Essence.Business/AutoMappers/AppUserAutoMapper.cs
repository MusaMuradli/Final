using AutoMapper;
using Essence.Business.Dtos.AppUserDtos;
using Essence.Core.Entities;

namespace Essence.Business.AutoMappers;

internal class AppUserAutoMapper : Profile
{
    public AppUserAutoMapper()
    {
        CreateMap<AppUser, RegisterDto>().ReverseMap();
        CreateMap<AppUser, UserGetDto>().ReverseMap();
    }
}
