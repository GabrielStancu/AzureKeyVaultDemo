using GamificationPlatform.Core.Models;

namespace GamificationPlatform.Infrastructure.Dtos;

public class LeaderboardResponseDto
{
    public IEnumerable<User> Users { get; set; } = null!;
    public int Rank { get; set; }
}