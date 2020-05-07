namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using Trainings.Business.Interfaces;
    using Trainings.Common.Helpers;
    using Trainings.Controller.Assembler;
    using Trainings.Controller.Constants;
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;


    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        #region Constructor & Properties

        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        #endregion

        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            IEnumerable<string> parameters = new List<string> 
            { 
                signUpViewModel.FirstName,
                signUpViewModel.LastName,
                signUpViewModel.Email,
                signUpViewModel.Password 
            };
            if (parameters.HasAtLeastOneNullOrWhitespace())
            {
                return BadRequest(new { message = ErrorsConstants.OneParameterIncorrect });
            }

            SignUpModel signUpModel = signUpViewModel.ToSignUpModel();
            TokenModel tokenModel = _authManager.SignUp(signUpModel);
            TokenViewModel tokenViewModel = tokenModel.ToTokenViewModel();

            if (tokenViewModel.IsNull())
            {
                return BadRequest(new { message = ErrorsConstants.EmailAlreadyUsed });
            }

            return Ok(tokenViewModel.JwtToken);
        }

        [AllowAnonymous]
        [HttpGet("signin")]
        public IActionResult SignIn(string Email, string Password)
        {
            IEnumerable<string> parameters = new List<string> { Email, Password };
            if (parameters.HasAtLeastOneNullOrWhitespace())
            {
                return BadRequest(new { message = ErrorsConstants.EmailOrPasswordEmpty });
            }

            SignInModel signInModel = new SignInModel { Email = Email, Password = Password };
            TokenModel tokenModel = _authManager.SignIn(signInModel);
            TokenViewModel tokenViewModel = tokenModel.ToTokenViewModel();

            if (tokenViewModel.IsNull())
            {
                return BadRequest(new { message = ErrorsConstants.EmailOrPasswordIncorrect });
            }

            return Ok(tokenViewModel.JwtToken);
        }

        [Authorize]
        [HttpGet("me")]
        public IList<string> Me()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claims = identity.Claims.ToList();
            IList<string> values = new List<string>();
            for (int i = 0; i < claims.Count; i++)
            {
                string value = claims[i].Value;
                values.Add(value);
            }
            return values;
        }
    }
}
