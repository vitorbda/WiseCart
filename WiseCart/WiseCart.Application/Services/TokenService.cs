using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;
using WiseCart.Domain.Interfaces.Services;

namespace WiseCart.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _uow;
        private readonly ISecurityService _securityService;

        public TokenService(IConfiguration config, IUnitOfWork uow, ISecurityService securityService)
        {
            _config = config;
            _uow = uow;
            _securityService = securityService;
        }

        public async Task<(JwtSecurityToken accessToken, string refreshToken)> GenerateTokenAsync(LoginDTO loginDTO)
        {
            var userEntity = await _uow.UserRepository.GetUserByUsernameAsync(loginDTO.UserName);

            if (userEntity is null 
                || !_securityService.VerifyPassword(loginDTO.Password, userEntity.Password))
                return (null, string.Empty);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            _ = int.TryParse(_config["JWT:TokenValidityHours"], out int expiryHours);

            var tokenOptions = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                expires: DateTime.Now.AddHours(expiryHours),
                claims: new[]
                {
                    new Claim("username", userEntity.UserName),
                    new Claim("role", userEntity.Role),
                    new Claim("id", userEntity.Id.ToString())
                },
                signingCredentials: signingCredentials
            );

            var refreshToken = GenerateRefreshToken();
            await SaveRefreshTokenAsync(refreshToken, userEntity.Id);
            await _uow.CommitAsync();

            return (tokenOptions, refreshToken);
        }

        public string GenerateRefreshToken()
        {
            var secureRandomBytes = new byte[128];

            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(secureRandomBytes);

            var refreshToken = Convert.ToBase64String(secureRandomBytes);

            return refreshToken;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var secretKey = _config["JWT:Key"] ?? throw new ArgumentNullException("JWT:key");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["JWT:Issuer"],
                ValidAudience = _config["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateLifetime = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public async Task<ClaimsPrincipal> ValidateRefreshTokenAsync(string refreshToken)
        {
            var refreshTokenEntity = await _uow.RefreshTokenRepository.GetByTokenAsync(refreshToken);

            if (refreshTokenEntity is null || refreshTokenEntity.ExpiryDate < DateTime.Now)
                return null;

            var userEntity = await _uow.UserRepository.GetAsync(refreshTokenEntity.UserId);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userEntity.UserName),
                new Claim(ClaimTypes.Role, userEntity.Role)
            };

            var identity = new ClaimsIdentity(claims, "refreshToken");
            var principal = new ClaimsPrincipal(identity);

            return principal;
        }

        private async Task SaveRefreshTokenAsync(string refreshToken, Guid userId)
        {
            _ = int.TryParse(_config["JWT:RefreshTokenValidityDays"], out int expiryDays);

            var refreshTokenEntity = new RefreshToken
            {
                UserId = userId,
                Token = refreshToken,
                ExpiryDate = DateTime.Now.AddDays(expiryDays)
            };

            await _uow.RefreshTokenRepository.CreateAsync(refreshTokenEntity);
        }

        public async Task<(JwtSecurityToken accessToken, string refreshToken)> RefreshTokenAsync(string refreshToken)
        {
            var principal = await ValidateRefreshTokenAsync(refreshToken);
            if (principal is null)
                return (null, string.Empty);

            var userEntity = await _uow.UserRepository.GetUserByUsernameAsync(principal.Identity.Name);
            if (userEntity is null)
                return (null, string.Empty);

            var (newToken, newRefreshToken) = await GenerateTokenAsync(new LoginDTO
            {
                UserName = userEntity.UserName,
                Password = userEntity.Password
            });

            return (newToken, newRefreshToken);
        }
    }
}
