using Microsoft.AspNetCore.Mvc;
using OutOfOffice.BLL.Services.Interfaces;
using OutOfOffice.Common.DTOs.Auth;

namespace OutOfOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserDTO dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserDTO dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }

    }
}
