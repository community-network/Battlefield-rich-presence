using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BattlefieldRichPresence.Properties
{
    internal class Jwt
    {
        public static string Create(string dataString, string guid = "")
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;

            var claims_identity = new ClaimsIdentity(new[]
                {
                    new Claim( "post", dataString)
                });
            if (guid != "")
            {
                claims_identity = new ClaimsIdentity(new[]
                {
                    new Claim( "guid", guid ),
                    new Claim( "post", dataString)
                });
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims_identity,
                Expires = now.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SUPERSECRETPLACEHOLDER")), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}