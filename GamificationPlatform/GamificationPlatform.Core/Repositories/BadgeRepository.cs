using GamificationPlatform.Core.Context;
using GamificationPlatform.Core.Models;

namespace GamificationPlatform.Core.Repositories;

public interface IBadgeRepository : IGenericRepository<Badge>
{

}

public class BadgeRepository : GenericRepository<Badge>, IBadgeRepository
{
    public BadgeRepository(AppDbContext context) : base(context)
    {
    }
}