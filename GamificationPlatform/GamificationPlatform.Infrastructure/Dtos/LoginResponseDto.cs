namespace GamificationPlatform.Infrastructure.Dtos;

public class LoginResponseDto
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public int Points { get; set; }
}