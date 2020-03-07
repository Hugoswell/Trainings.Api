using Trainings.Business.Interface;
using Trainings.Controller.Assembler;
using Trainings.ViewModel;

namespace Trainings.Controller.Controller
{
    public class AuthController
    {
        #region Constructor & Properties

        private readonly IAuthBusiness _userBusiness;

        public AuthController(IAuthBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        #endregion

        public void SignUp(string firstName, string lastName, string email, string password)
        {
            SignUpViewModel signUpViewModel = UserAssembler.ToSignUpViewModel(firstName, lastName, email, password);
            _userBusiness.SignUp(signUpViewModel);
        }
    }
}
