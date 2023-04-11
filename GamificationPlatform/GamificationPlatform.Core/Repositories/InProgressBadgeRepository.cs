using GamificationPlatform.Core.Context;
using GamificationPlatform.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GamificationPlatform.Core.Repositories;

public interface IInProgressBadgeRepository : IGenericRepository<InProgressBadge>
{
    Task<IEnumerable<Badge>> GetInProgressBadges(int userId);
    Task<IEnumerable<Badge>> GetStartedChallengesByUserAsync(int userId);
}

public class InProgressBadgeRepository : GenericRepository<InProgressBadge>, IInProgressBadgeRepository
{
    public InProgressBadgeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Badge>> GetInProgressBadges(int userId)
    {
        var inProgressBadges = await Context.InProgressBadge
            .Where(b => b.UserId == userId)
            .Include(b => b.Bagde)
            .Select(b => b.Bagde)
            .ToListAsync();

        return inProgressBadges;
    }

    public async Task<IEnumerable<Badge>> GetStartedChallengesByUserAsync(int userId)
    {
        var challenges = await Context.InProgressBadge
            .Where(b => b.UserId == userId)
            .Include(b => b.Bagde)
            .Select(b => b.Bagde)
            .ToListAsync();

        return challenges;
    }
}