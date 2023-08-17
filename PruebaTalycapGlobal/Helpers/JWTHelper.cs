using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTalycapGlobal.Helpers
{
    public class JWTHelper
    {
        private readonly byte[] secret;
        public JWTHelper(string secretKey)
        {
            this.secret = Encoding.ASCII.GetBytes(secretKey);
        }
        /*
        public string CreateToken(string userName)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.secret), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(createdToken);
        }*/

        public string GenerateToken(string secretKey, string issuer, string audience, int expireMinutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, "username"),
            // Agrega más reclamaciones según tus necesidades
        }),
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
