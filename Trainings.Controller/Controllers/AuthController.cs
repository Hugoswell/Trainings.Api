namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Trainings.Business.Interfaces;
    using Trainings.Common.Helpers;
    using Trainings.Controller.Assembler;
    using Trainings.Controller.Constants;
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;


    [ApiController]
    [AllowAnonymous]
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

        [HttpPost("SignUp")]
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

        [HttpGet("SignIn")]
        public IActionResult SignIn(SignInViewModel signInViewModel)
        {
            IEnumerable<string> parameters = new List<string> { signInViewModel.Email, signInViewModel.Password };
            if (parameters.HasAtLeastOneNullOrWhitespace())
            {
                return BadRequest(new { message = ErrorsConstants.EmailOrPasswordEmpty });
            }

            SignInModel signInModel = signInViewModel.ToSignInModel();
            TokenModel tokenModel = _authManager.SignIn(signInModel);
            TokenViewModel tokenViewModel = tokenModel.ToTokenViewModel();

            if (tokenViewModel.IsNull())
            {
                return BadRequest(new { message = ErrorsConstants.EmailOrPasswordIncorrect });
            }

            return Ok(tokenViewModel.JwtToken);
        }
    }
}
