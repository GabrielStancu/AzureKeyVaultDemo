using GamificationPlatform.Core.Context;
using GamificationPlatform.Core.Models;

namespace GamificationPlatform.Core.Repositories;

public interface IInProgressBadgeRepository : IGenericRepository<InProgressBadge>
{
}

public class InProgressBadgeRepository : GenericRepository<InProgressBadge>, IInProgressBadgeRepository
{
    public InProgressBadgeRepository(AppDbContext context) : base(context)
    {
    }
}