using ApiVete.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ApiVete.Services
{
    public interface IJwtService
    {
        string GenerateToken(string username, IDictionary<string, string>? additionalClaims = null);
    }

    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string username, IDictionary<string, string>? additionalClaims = null)
        {
            var key = _config["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key no configurado");
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiresMinutes = int.TryParse(_config["Jwt:ExpiresMinutes"], out var m) ? m : 60;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims.Select(kv => new Claim(kv.Key, kv.Value)));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}