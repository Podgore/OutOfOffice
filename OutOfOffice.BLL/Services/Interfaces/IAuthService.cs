using OutOfOffice.Common.DTOs.Auth;

namespace OutOfOffice.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthSuccessDTO> LoginAsync(LoginUserDTO dto);
        public Task<AuthSuccessDTO> RegisterAsync(RegisterUserDTO dto);
    }
}
