using Microsoft.Extensions.DependencyInjection;

namespace GamificationPlatform.Infrastructure.Services;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBadgeService, BadgeService>();
        services.AddScoped<IInProgressBadgeService, InProgressBadgeService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ILeaderboardService, LeaderboardService>();
    }
}