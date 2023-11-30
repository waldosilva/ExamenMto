using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarlosMto.Application.Services.JWT
{
    public class JwtService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtService(string secretKey, string issuer, string audience)
        {
            _secretKey = secretKey;
            _issuer = issuer;
            _audience = audience;
        }
        public JwtService(string secretKey)
        {
            _secretKey = secretKey;
            //_issuer = issuer;
            //_audience = audience;
        }

        public string GenerateToken(string userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId)
            // Puedes agregar más claims según lo necesites para la identidad del usuario
        };

            var token = new JwtSecurityToken(
                //issuer: _issuer,
                //audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Cambia la expiración según tus necesidades
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
