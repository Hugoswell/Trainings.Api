namespace Trainings.Controller.Controller
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
        [HttpPost]
        public void SignUp(string firstName, string lastName, string email, string password)
        {
            SignUpViewModel signUpViewModel = UserAssembler.ToSignUpViewModel(firstName, lastName, email, password);
            _authBusiness.SignUp(signUpViewModel);
        }

        [HttpPost("token")]
        public IActionResult GenerateToken()
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
                    //issuer: "hugo",
                    audience: "readers",
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                );

            //return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        [Authorize]
        [HttpGet("values")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
