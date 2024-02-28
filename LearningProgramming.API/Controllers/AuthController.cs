using LearningProgramming.Application.Contracts.Identity.Services;
using LearningProgramming.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearningProgramming.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await authService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await authService.Register(request));
        }

        [HttpGet("getNewAccessToken/{refreshToken}")]
        public async Task<ActionResult<AuthResponse>> GetNewAccessToken(string refreshToken)
        {
            var response = await authService.GetNewAccessToken(refreshToken);

            if (response is null)
                return Unauthorized();

            return Ok(response);
        }
    }
}
