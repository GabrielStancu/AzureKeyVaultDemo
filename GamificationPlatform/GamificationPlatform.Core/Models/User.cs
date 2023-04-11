namespace GamificationPlatform.Core.Models;

public class User : ModelBase
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Points { get; set; }
}