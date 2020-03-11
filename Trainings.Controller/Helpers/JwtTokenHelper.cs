using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Trainings.Controller.Constants;
using Trainings.Controller.Interfaces;

namespace Trainings.Controller.Helpers
{
    public class JwtTokenHelper : IJwtTokenHelper
    {
        private readonly IConfiguration _configuration;

        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken()
        {
            //security key
            string secretKey = _configuration[AppSettings.SecretKey];
            //symetric security key
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //credentials
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //create token
            var token = new JwtSecurityToken
                (
                    issuer: "Trainings",
                    audience: "freeAccounts",
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                );

            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
