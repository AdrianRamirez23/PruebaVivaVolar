using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Middleware
{
    public class JWTAuthenticationManager: IJWTAuthenticationManager
    {
        private readonly IConfiguration _config;
        public JWTAuthenticationManager(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string Autheticate(string UserName) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_config.GetSection("JwtConfig").GetSection("secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var toke = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(toke);
        }
    }
}
