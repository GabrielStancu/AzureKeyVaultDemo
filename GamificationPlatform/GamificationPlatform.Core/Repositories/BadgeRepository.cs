using GamificationPlatform.Core.Context;
using GamificationPlatform.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GamificationPlatform.Core.Repositories;

public interface IBadgeRepository : IGenericRepository<Badge>
{
    Task<IEnumerable<Badge>> GetUserProposedBadges(int userId);
    Task<IEnumerable<Badge>> GetUserOwnedBadges(int userId);
    Task<IEnumerable<Badge>> GetUserChallenges(int userId);
}

public class BadgeRepository : GenericRepository<Badge>, IBadgeRepository
{
    public BadgeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Badge>> GetUserProposedBadges(int userId)
    {
        var proposedBadges = await Context.Badge
            .Where(b => b.CreatorId == userId)
            .ToListAsync();

        return proposedBadges;
    }

    public async Task<IEnumerable<Badge>> GetUserOwnedBadges(int userId)
    {
        var ownedBadges = await Context.Badge
            .Where(b => b.SolverId == userId)
            .ToListAsync();

        return ownedBadges;
    }

    public async Task<IEnumerable<Badge>> GetUserChallenges(int userId)
    {
        var challenges = await Context.Badge
            .Where(b => b.CreatorId != userId && b.SolverId == null)
            .ToListAsync();

        return challenges;
    }
}