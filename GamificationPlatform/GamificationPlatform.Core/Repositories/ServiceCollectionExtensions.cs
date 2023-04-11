using Microsoft.Extensions.DependencyInjection;

namespace GamificationPlatform.Core.Repositories;

public static class ServiceCollectionExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBadgeRepository, BadgeRepository>();
        services.AddScoped<IInProgressBadgeRepository, InProgressBadgeRepository>();
    }
}