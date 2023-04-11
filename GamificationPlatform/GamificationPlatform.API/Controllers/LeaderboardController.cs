using GamificationPlatform.Infrastructure.Dtos;
using GamificationPlatform.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamificationPlatform.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaderboardController : ControllerBase
{
    private readonly ILeaderboardService _service;

    public LeaderboardController(ILeaderboardService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<LoginResponseDto>> Login(LeaderboardRequestDto request)
    {
        var result = await _service.LeaderboardAsync(request);

        return Ok(result);
    }
}
