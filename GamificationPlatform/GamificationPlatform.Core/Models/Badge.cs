namespace GamificationPlatform.Core.Models;

public class Badge : ModelBase
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Points { get; set; }
    public int CreatorId { get; set; }
    public User Creator { get; set; } = null!;
    public int? SolverId { get; set; }
    public User? Solver { get; set; }
}