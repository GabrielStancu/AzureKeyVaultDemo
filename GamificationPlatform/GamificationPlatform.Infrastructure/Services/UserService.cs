using AutoMapper;
using GamificationPlatform.Core.Repositories;
using GamificationPlatform.Infrastructure.Dtos;

namespace GamificationPlatform.Infrastructure.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
}

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _repository.SelectAllAsync();

        return _mapper.Map<IEnumerable<UserDto>>(users);
    }
}