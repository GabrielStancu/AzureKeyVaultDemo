using GamificationPlatform.Core.Repositories;
using GamificationPlatform.Infrastructure.Dtos;

namespace GamificationPlatform.Infrastructure.Services;

public interface ILeaderboardService
{
    Task<LeaderboardResponseDto> LeaderboardAsync(LeaderboardRequestDto request);
}

public class LeaderboardService : ILeaderboardService
{
    private readonly IUserRepository _userRepository;

    public LeaderboardService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<LeaderboardResponseDto> LeaderboardAsync(LeaderboardRequestDto request)
    {
        var result = await _userRepository.GetLeaderboardAsync(request.TopCount, request.UserId);
        var response = new LeaderboardResponseDto
        {
            Users = result.Users,
            Rank = result.Rank
        };

        return response;
}