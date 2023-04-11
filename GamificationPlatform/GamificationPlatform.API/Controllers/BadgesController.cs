using GamificationPlatform.Core.Models;
using GamificationPlatform.Infrastructure.Dtos;
using GamificationPlatform.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamificationPlatform.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BadgesController : ControllerBase
{
    private readonly IBadgeService _badgeService;

    public BadgesController(IBadgeService badgeService)
    {
        _badgeService = badgeService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserBadgesResponseDto>> GetUserBadges(int userId)
    {
        var result = await _badgeService.GetUserBadgesAsync(userId);
        return Ok(result);
    }

    [HttpGet("owned/{userId}")]
    public async Task<ActionResult<IEnumerable<Badge>>> GetUserOwnedBadges(int userId)
    {
        var result = await _badgeService.GetUserOwnedBadges(userId);
        return Ok(result);
    }

    [HttpGet("proposed/{userId}")]
    public async Task<ActionResult<IEnumerable<Badge>>> GetUserProposedBadges(int userId)
    {
        var result = await _badgeService.GetUserProposedBadges(userId);
        return Ok(result);
    }

    [HttpGet("in-progress/{userId}")]
    public async Task<ActionResult<IEnumerable<Badge>>> GetUserInProgressBadges(int userId)
    {
        var result = await _badgeService.GetUserInProgressBadges(userId);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateBadge(Badge badge)
    {
        await _badgeService.CreateBadgeAsync(badge);
        return Ok();
    }

    [HttpPost("assign")]
    public async Task<ActionResult> AssignBadge(Badge badge)
    {
        await _badgeService.AssignBadgeAsync(badge);
        return Ok();
    }

    [HttpGet("challenges/{userId}")]
    public async Task<ActionResult<IEnumerable<Badge>>> GetChallenges(int userId)
    {
        var challenges = await _badgeService.GetUserChallengesAsync(userId);
        return Ok(challenges);
    }
}
