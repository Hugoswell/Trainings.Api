namespace Trainings.Controller.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Trainings.Business.Interface;
    using Trainings.Common.Helpers;
    using Trainings.Controller.Assembler;
    using Trainings.Controller.Constants;
    using Trainings.Controller.Interfaces;
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;

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
                return BadRequest(new { message = AuthSettings.BadRequestOneParameterIncorrect });
            }
            
            UserModel userManagerModel = _authBusiness.SignUp(UserControllerAssembler.ToUserModel(firstName, lastName, email, password));
            UserViewModel userViewModel = userManagerModel.ToUserViewModel();

            if (userViewModel.IsNull())
            {
                return BadRequest(new { message = AuthSettings.BadRequestEmailAlreadyUsed });
            }

            string token = _jwtTokenHelper.GenerateJwtToken(AuthSettings.FreeRole, 1);
            userViewModel.JwtToken = token;

            return Ok(userViewModel);
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("test");
        }
    }
}
