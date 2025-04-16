using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WiseCart.Application.DTOs;

namespace WiseCart.Application.Interfaces
{
    public interface ITokenService
    {
        Task<(JwtSecurityToken accessToken, string refreshToken)> GenerateTokenAsync(LoginDTO loginDTO);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<ClaimsPrincipal> ValidateRefreshTokenAsync(string refreshToken);
        Task<(JwtSecurityToken accessToken, string refreshToken)> RefreshTokenAsync(string refreshToken);
    }
}
