using GamificationPlatform.Infrastructure.Dtos;
using GamificationPlatform.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamificationPlatform.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> Login(LeaderboardRequestDto request)
    {
        var users = await _userService.GetUsersAsync();
        return Ok(users);
    }
}
