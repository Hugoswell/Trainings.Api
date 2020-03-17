namespace Trainings.Controller.Helpers
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Trainings.Controller.Constants;
    using Trainings.Controller.Interfaces;

    public class JwtTokenHelper : IJwtTokenHelper
    {
        private readonly IConfiguration _configuration;

        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string role, int expiresMinutes)
        {
            //security key
            string secretKey = _configuration[AppSettings.SecretKey];
            //symetric security key
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //credentials
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //add claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role)
            };

            //create token
            var token = new JwtSecurityToken
                (
                    issuer: "Trainings",
                    audience: "Audience",
                    expires: DateTime.Now.AddMinutes(expiresMinutes),
                    signingCredentials: signingCredentials,
                    claims: claims
                ); ;

            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
