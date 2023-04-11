using GamificationPlatform.Core.Context;
using GamificationPlatform.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GamificationPlatform.Core.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> LoginAsync(string username, string password);
    Task SignupAsync(User user);
    Task<bool> UserExistsAsync(string email);
    Task<(IEnumerable<User> Users, int Rank)> GetLeaderboardAsync(int topCount, int userId);
}

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User> LoginAsync(string username, string password)
    {
#pragma warning disable CS8603
        return await Context.User
            .FirstOrDefaultAsync(w => w.Username.Equals(username) &&
                                      w.Password.Equals(password));
#pragma warning restore CS8603
    }

    public async Task SignupAsync(User user)
    {
        await InsertAsync(user);
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        var user = await Context.User.FirstOrDefaultAsync(u => u.Email == email);

        return user != null;
    }

    public async Task<(IEnumerable<User> Users, int Rank)> GetLeaderboardAsync(int topCount, int userId)
    {
        var users = await Context.User
            .OrderBy(u => u.Points)
            .Take(topCount)
            .ToListAsync();

        var user = await SelectByIdAsync(userId);

        var rank = (await Context.User
            .OrderBy(u => u.Points)
            .Where(u => u.Points > user.Points)
            .ToListAsync()).Count + 1;

        return (users, rank);
    }
}