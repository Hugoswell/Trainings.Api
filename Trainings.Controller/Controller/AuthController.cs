namespace Trainings.Controller.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using Trainings.Business.Interface;
    using Trainings.Controller.Assembler;
    using Trainings.ViewModel;

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        
        #region Constructor & Properties

        private readonly IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        #endregion

        public void SignUp(string firstName, string lastName, string email, string password)
        {
            SignUpViewModel signUpViewModel = UserAssembler.ToSignUpViewModel(firstName, lastName, email, password);
            _authBusiness.SignUp(signUpViewModel);
        }
        
        [HttpPost("token")]
        public IActionResult GetToken(string name)
        {
            return Ok($"Hello {name} !");
        }
    }
}
