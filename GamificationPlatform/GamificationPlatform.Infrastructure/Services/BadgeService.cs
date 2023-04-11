using GamificationPlatform.Core.Models;
using GamificationPlatform.Core.Repositories;
using GamificationPlatform.Infrastructure.Dtos;

namespace GamificationPlatform.Infrastructure.Services;

public interface IBadgeService
{
    Task<UserBadgesResponseDto> GetUserBadgesAsync(int userId);
    Task<IEnumerable<Badge>> GetUserProposedBadges(int userId);
    Task<IEnumerable<Badge>> GetUserOwnedBadges(int userId);
    Task<IEnumerable<Badge>> GetUserInProgressBadges(int userId);
    Task CreateBadgeAsync(Badge badge);
    Task AssignBadgeAsync(Badge badge);
    Task<IEnumerable<Badge>> GetUserChallengesAsync(int userId);
}

public class BadgeService : IBadgeService
{
    private readonly IBadgeRepository _badgeRepository;
    private readonly IInProgressBadgeRepository _inProgressBadgeRepository;

    public BadgeService(IBadgeRepository badgeRepository, IInProgressBadgeRepository inProgressBadgeRepository)
    {
        _badgeRepository = badgeRepository;
        _inProgressBadgeRepository = inProgressBadgeRepository;
    }

    public async Task<UserBadgesResponseDto> GetUserBadgesAsync(int userId)
    {
        return new UserBadgesResponseDto
        {
            ProposedBadges = await GetUserProposedBadges(userId),
            OwnedBadges = await GetUserOwnedBadges(userId),
            InProgressBadges = await GetUserInProgressBadges(userId)
        };
    }

    public async Task<IEnumerable<Badge>> GetUserProposedBadges(int userId)
    {
        var badges = await _badgeRepository.GetUserProposedBadges(userId);
        return badges;
    }

    public async Task<IEnumerable<Badge>> GetUserOwnedBadges(int userId)
    {
        var badges = await _badgeRepository.GetUserOwnedBadges(userId);
        return badges;
    }

    public async Task<IEnumerable<Badge>> GetUserInProgressBadges(int userId)
    {
        var badges = await _inProgressBadgeRepository.GetInProgressBadges(userId);
        return badges;
    }

    public async Task CreateBadgeAsync(Badge badge)
    {
        await _badgeRepository.InsertAsync(badge);
    }

    public async Task AssignBadgeAsync(Badge badge)
    {
        await _badgeRepository.UpdateAsync(badge);
    }

    public async Task<IEnumerable<Badge>> GetUserChallengesAsync(int userId)
    {
        var initialChallenges = await _badgeRepository.GetUserChallenges(userId);
        var inProgressChallenges = await _inProgressBadgeRepository.GetStartedChallengesByUserAsync(userId);
        var badges = new List<Badge>();

        foreach (var challenge in initialChallenges)
        {
            var exists = inProgressChallenges.Any(c => c.Id == challenge.Id);

            if (!exists)
                badges.Add(challenge);
        }

        return badges;
    }
}