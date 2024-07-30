using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Models;
using Hackathon.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Hackathon.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        RefreshTokenModel GenerateRefreshToken();
        BaseOutput<string> ValidateLogin(User user, LoginDto loginDto);

        bool ValidateToken(string token);

        (ClaimsPrincipal, SecurityToken) GetClaimsPrincipal(string token);

        Task<BaseOutput<TokenDto>> RefreshExpiratedTokenAsync(TokenDto tokenDto);

    }
}
