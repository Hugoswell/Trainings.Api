namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Trainings.Business.Interface;
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

        public AuthController(IAuthManager authBusiness)
        {
            _authManager = authBusiness;
        }

        #endregion

        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult SignUp(string firstName, string lastName, string email, string password)
        {
            IEnumerable<string> parameters = new List<string> { firstName, lastName, email, password };
            if (parameters.HasAtLeastOneNullOrWhitespace())
            {
                return BadRequest(new { message = AuthConstants.OneParameterIncorrect });
            }
            
            UserModel userModel = _authManager.SignUp(UserControllerAssembler.BuildUserModel(email, password, firstName, lastName));
            UserViewModel userViewModel = userModel.ToUserViewModel();

            if (userViewModel.IsNull())
            {
                return BadRequest(new { message = AuthConstants.BadRequestEmailAlreadyUsed });
            }

            return Ok(userViewModel);
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult SignIn(string email, string password)
        {
            IEnumerable<string> parameters = new List<string> { email, password };
            if (parameters.HasAtLeastOneNullOrWhitespace())
            {
                return BadRequest(new { message = AuthConstants.EmailOrPasswordEmpty });
            }

            UserModel userModel = _authManager.SignIn(UserControllerAssembler.BuildUserModel(email, password));
            UserViewModel userViewModel = userModel.ToUserViewModel();

            if (userViewModel.IsNull())
            {
                return BadRequest(new { message = AuthConstants.EmailOrPasswordIncorrect });
            }

            return Ok(userViewModel);
        }

        [HttpGet("test")]
        [Authorize(Roles = "freee")]
        public IActionResult Get()
        {
            return Ok("test");
        }
    }
}
