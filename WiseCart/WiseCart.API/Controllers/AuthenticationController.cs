using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;
using WiseCart.Domain.Entities;

namespace WiseCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginDTO loginDTO)
        {
            var (accessToken, refreshtoken) = await _tokenService.GenerateTokenAsync(loginDTO);

            if (accessToken is null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(accessToken);

            return Ok(new
            {
                Token = tokenHandler,
                RefreshToken = refreshtoken,
                Expiration = accessToken.ValidTo
            });
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            var (newToken, newRefreshToken) = await _tokenService.RefreshTokenAsync(refreshTokenDTO.RefreshToken);

            if (newToken is null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(newToken);

            return Ok(new
            {
                Token = tokenHandler,
                RefreshToken = newRefreshToken,
                Expiration = newToken.ValidTo
            });
        }
    }
}
