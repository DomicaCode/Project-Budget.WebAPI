using Microsoft.IdentityModel.Tokens;
using Project_Budget.Model.Models.Authorization;
using Project_Budget.Model.Models.Membership;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        public IToken CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("DrhX3HpOxgAKo94ryrOaQbBVIdrKqJJ8");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = CreateUserClaims(user),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);

            return new Token
            {
                AccessToken = tokenHandler.WriteToken(jwtToken)
            };
        }

        private static ClaimsIdentity CreateUserClaims(User user)
        {
            return new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("userId", user.Id.ToString())
                });
        }
    }
}
