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

        [HttpPost("getNewAccessToken")]
        public async Task<ActionResult<AuthResponse>> GetNewAccessToken(TokenRequest request)
        {
            var response = await authService.GetNewAccessToken(request.RefreshToken);

            if (response is null)
                return Unauthorized();

            return Ok(response);
        }
    }
}
