using System.ComponentModel.DataAnnotations.Schema;

namespace GamificationPlatform.Core.Models;

public class InProgressBadge : ModelBase
{
    public int UserId { get; set; }
    [ForeignKey("Badge")]
    public int BadgeId { get; set; }
    public Badge Bagde { get; set; }
}