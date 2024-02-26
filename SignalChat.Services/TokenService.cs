using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SignalChat.Common;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.Auth;
using SignalChat.Models.Auth.Interfaces;
using SignalChat.Services.Exceptions;
using SignalChat.Services.Interfaces;

namespace SignalChat.Services;

/// <summary>
/// Сервис токенов.
/// </summary>
public class TokenService(IAuthSettings authSettings, IUserRepository userRepository) : ITokenService
{
    public string CreateToken(IEnumerable<Claim> claims, int tokenExpiresAfterHours = 0)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key));

        if (tokenExpiresAfterHours == 0)
        {
            tokenExpiresAfterHours = authSettings.TokenExpiresAfterHours;
        }

        var token = new JwtSecurityToken(authSettings.Issuer, authSettings.Audience, claims, null, DateTime.UtcNow.AddHours(tokenExpiresAfterHours),
            new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<AuthResponse> RefreshToken(string refreshToken)
    {
        var user = await userRepository.GetUserByRefreshToken(refreshToken);
        if (user == null)
        {
            throw new RefreshTokenNotFoundException();
        }

        var claims = Jwt.GetClaims(user.Id, user.Role, user.Email, user.Username);
        var newRefreshToken = CreateToken(new List<Claim>());
        var newAccessToken = CreateToken(claims, 24);

        await userRepository.UpdateRefreshToken(user.Id, newRefreshToken, DateTime.UtcNow.AddHours(authSettings.TokenExpiresAfterHours));

        return new AuthResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }
}