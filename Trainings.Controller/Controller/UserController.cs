namespace Trainings.Controller.Controllers
{
    using Trainings.Business.Interface;
    using Trainings.Controller.Assembler;
    using Trainings.ViewModel;

    public class UserController
    {
        #region Constructor & Properties

        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
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
