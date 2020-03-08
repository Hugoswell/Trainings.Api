namespace Trainings.Business
{
    using System;
    using Trainings.Business.Assembler;
    using Trainings.Business.Interface;
    using Trainings.Data.Models;
    using Trainings.Repository.Interface;
    using Trainings.ViewModel;

    public class AuthBusiness : IAuthBusiness
    {
        #region Constructor & Properties

        private readonly IAuthRepository _authRepository;

        public AuthBusiness(IAuthRepository authRepository)
        {
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        }

        #endregion

        #region SignUp

        public void SignUp(SignUpViewModel signUpViewModel)
        {
            User user = signUpViewModel.SignUpViewModelToUser();
            _authRepository.SignUp(user);
        }

        #endregion
    }
}
