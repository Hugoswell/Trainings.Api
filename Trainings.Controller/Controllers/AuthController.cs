namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using Trainings.Business.Interface;
    using Trainings.Controller.Assembler;
    using Trainings.Controller.Constants;
    using Trainings.Controller.Helpers;
    using Trainings.Data.Models;
    using Trainings.ViewModel;

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        #region Constructor & Properties

        private readonly IAuthBusiness _authBusiness;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthBusiness authBusiness, IConfiguration configuration)
        {
            _configuration = configuration;
            _authBusiness = authBusiness;
        }

        #endregion

        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult SignUp(string firstName, string lastName, string email, string password)
        {
            IEnumerable<string> parameters = new List<string> { firstName, lastName, email, password };
            if (!parameters.NoneStringIsNullOrWhitespace())
            {
                return BadRequest(new { message = "At least one of the parameters is incorrect" });
            }

            SignUpViewModel signUpViewModel = UserAssembler.ToSignUpViewModel(firstName, lastName, email, password);
            User user = _authBusiness.SignUp(signUpViewModel);

            if (user.IsNull())
            {
                return NotFound(); //find better response object
            }
            //token
            return Ok(user);
        }
        
        private string GenerateToken()
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
