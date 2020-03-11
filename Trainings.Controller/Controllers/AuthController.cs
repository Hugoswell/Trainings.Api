namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Trainings.Business.Interface;
    using Trainings.Business.Models;
    using Trainings.Controller.Assembler;
    using Trainings.Controller.Helpers;
    using Trainings.Controller.Interfaces;
    using Trainings.ViewModel;

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        #region Constructor & Properties

        private readonly IAuthBusiness _authBusiness;
        private readonly IJwtTokenHelper _jwtTokenHelper;

        public AuthController(IAuthBusiness authBusiness, IJwtTokenHelper jwtTokenHelper)
        {
            _authBusiness = authBusiness;
            _jwtTokenHelper = jwtTokenHelper;
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

            SignUpViewModel signUpViewModel = UserControllerAssembler.ToSignUpViewModel(firstName, lastName, email, password);            
            UserManagerModel userManagerModel = _authBusiness.SignUp(signUpViewModel.ToUserManagerModel());
            UserViewModel userViewModel = userManagerModel.ToUserViewModel();

            if (userViewModel.IsNull())
            {
                return NotFound(); //find better response object
            }

            string token = _jwtTokenHelper.GenerateJwtToken();
            userViewModel.JwtToken = token;

            return Ok(userViewModel);
        }                
    }
}
