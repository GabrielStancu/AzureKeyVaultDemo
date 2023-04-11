using AutoMapper;
using GamificationPlatform.Core.Models;
using GamificationPlatform.Core.Repositories;
using GamificationPlatform.Infrastructure.Dtos;

namespace GamificationPlatform.Infrastructure.Services;

public interface IAccountService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
    Task<bool> SignupAsync(SignupRequestDto signupRequestDto);
}

public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AccountService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var user = await _userRepository.LoginAsync(loginRequestDto.Username, loginRequestDto.Password);

#pragma warning disable CS8603
        return user is null ? null : _mapper.Map<User, LoginResponseDto>(user);
#pragma warning restore CS8603
    }

    public async Task<bool> SignupAsync(SignupRequestDto signupRequestDto)
    {
        if (await _userRepository.UserExistsAsync(signupRequestDto.Email))
            return false;

        var user = _mapper.Map<User>(signupRequestDto);
        user.Points = 0;
        await _userRepository.InsertAsync(user);

        return true;
    }
}