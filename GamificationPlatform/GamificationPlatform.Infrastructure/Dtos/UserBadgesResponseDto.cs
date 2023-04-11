using GamificationPlatform.Core.Models;

namespace GamificationPlatform.Infrastructure.Dtos;

public class UserBadgesResponseDto
{
    public IEnumerable<Badge> ProposedBadges { get; set; } = null!;
    public IEnumerable<Badge> OwnedBadges { get; set; } = null!;
    public IEnumerable<Badge> InProgressBadges { get; set; } = null!;
}