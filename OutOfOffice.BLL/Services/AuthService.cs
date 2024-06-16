using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OutOfOffice.BLL.Services.Interfaces;
using OutOfOffice.Common.Configs;
using OutOfOffice.Common.DTOs.Auth;
using OutOfOffice.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace OutOfOffice.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Employee> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        public AuthService(UserManager<Employee> userManager, IOptions<JwtConfig> jwtConfig, IMapper mapper) 
        { 
            _userManager = userManager;
            _jwtConfig = jwtConfig.Value;
            _mapper = mapper;
        }

        public async Task<AuthSuccessDTO> LoginAsync(LoginUserDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email)
            ?? throw new Exception($"Unable to find user by specified email. Email: {dto.Email}");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!isPasswordValid)
                throw new Exception($"User input incorrect password. Password: {dto.Password}");

            return new AuthSuccessDTO(await GenerateJwtTokenAsync(user));
        }

        public async Task<AuthSuccessDTO> RegisterAsync(RegisterUserDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
                throw new Exception($"User with specified email already exists. Email: {dto.Email}");

            user = _mapper.Map<Employee>(dto);

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new Exception($"User manager operation failed: {result.Errors}");

            return new AuthSuccessDTO(await GenerateJwtTokenAsync(user));
        }

        public async Task<string> GenerateJwtTokenAsync(Employee user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            var claims = new List<Claim>
            {
            new Claim("id", user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //Todo: add roles for users
            //var roles = await _userManager.GetRolesAsync(user);
            //claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtConfig.AccessTokenLifeTime),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
