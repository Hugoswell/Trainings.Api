namespace Trainings.Business.Helpers
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Trainings.Business.Interfaces;
    using Trainings.Common.Constants;

    public class JwtTokenHelper : IJwtTokenHelper
    {
        private readonly IConfiguration _configuration;

        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string userId, string userRole, string userFirstName, bool hasFilledInformation, int expiresMinutes)
        {
            //security key
            string secretKey = _configuration[AppSettings.SecretKey];
            //symetric security key
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //credentials
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //create token description
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, userId),
                        new Claim(ClaimTypes.Name, userFirstName),
                        new Claim(ClaimTypes.Role, userRole),
                        new Claim(ClaimTypes.DateOfBirth, hasFilledInformation.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(expiresMinutes),
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //create token
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            //return token
            return tokenHandler.WriteToken(token);
        }
    }
}
