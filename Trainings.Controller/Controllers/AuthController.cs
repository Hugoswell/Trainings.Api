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
        public IActionResult SignUp(string firstName, string lastName, string email, string password)
        {
            IEnumerable<string> parameters = new List<string> { firstName, lastName, email, password };
            if (parameters.HasAtLeastOneNullOrWhitespace())
            {
                return BadRequest(new { message = ErrorsConstants.OneParameterIncorrect });
            }
            
            UserModel userModel = _authManager.SignUp(UserControllerAssembler.BuildUserModel(email, password, firstName, lastName));
            UserViewModel userViewModel = userModel.ToUserViewModel();

            if (userViewModel.IsNull())
            {
                return BadRequest(new { message = ErrorsConstants.EmailAlreadyUsed });
            }

            return Ok(userViewModel);
        }

        [HttpPost("SignIn")]
        public IActionResult SignIn(string email, string password)
        {
            IEnumerable<string> parameters = new List<string> { email, password };
            if (parameters.HasAtLeastOneNullOrWhitespace())
            {
                return BadRequest(new { message = ErrorsConstants.EmailOrPasswordEmpty });
            }

            UserModel userModel = _authManager.SignIn(UserControllerAssembler.BuildUserModel(email, password));
            UserViewModel userViewModel = userModel.ToUserViewModel();

            if (userViewModel.IsNull())
            {
                return BadRequest(new { message = ErrorsConstants.EmailOrPasswordIncorrect });
            }

            return Ok(userViewModel);
        }
    }
}
