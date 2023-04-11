namespace GamificationPlatform.Infrastructure.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Points { get; set; }
}