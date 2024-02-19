using LearningProgramming.Application.Contracts.Identity;
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

        [HttpPost("refreshToken")]
        public async Task<ActionResult<AuthResponse>> RefreshToken([FromBody] TokenRequest request)
        {
            var response = await authService.RefreshToken(request);

            if (response is null)
                return Unauthorized();

            return Ok(response);
        }
    }
}
