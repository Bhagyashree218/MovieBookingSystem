using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kemar.MBS.Business.Helpers
{
    public class JwtToken
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiryInMinutes;

        public JwtToken(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
            _expiryInMinutes = int.Parse(configuration["Jwt:ExpiryInMinutes"]);
        }

        public string GenerateToken(int id, string email, string role)
        {
            // 1️⃣ Create security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // 2️⃣ Create token claims (WITH JTI)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),

                // ⭐ UNIQUE TOKEN ID FOR REFRESH TOKEN VALIDATION
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // 3️⃣ Build JWT
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_expiryInMinutes),
                signingCredentials: credentials
            );

            // 4️⃣ Convert to string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
