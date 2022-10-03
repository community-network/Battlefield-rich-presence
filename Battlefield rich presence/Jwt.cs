using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BattlefieldRichPresence
{
    internal class Jwt
    {
        public static string Create(string dataString, string guid = "")
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;

            var claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim( "post", dataString)
                });
            if (guid != "")
            {
                claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim( "guid", guid ),
                    new Claim( "post", dataString)
                });
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = now.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SUPERSECRETPLACEHOLDER")), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}