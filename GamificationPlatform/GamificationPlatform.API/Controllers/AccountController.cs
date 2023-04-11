using GamificationPlatform.Infrastructure.Dtos;
using GamificationPlatform.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamificationPlatform.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto loginRequestDto)
    {
        var loginResultDto = await _accountService.LoginAsync(loginRequestDto);

        if (loginResultDto != null)
        {
            return Ok(loginResultDto);
        }

        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<ActionResult<bool>> Register(SignupRequestDto userRegisterRequestDto)
    {
        bool registeredWatcher = await _accountService.SignupAsync(userRegisterRequestDto);
        return Ok(registeredWatcher);
    }
}
