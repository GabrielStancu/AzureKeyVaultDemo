using AutoMapper;
using GamificationPlatform.Core.Models;

namespace GamificationPlatform.Infrastructure.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginResponseDto>();
        CreateMap<SignupRequestDto, User>();
        CreateMap<User, UserDto>();
    }
}