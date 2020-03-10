namespace Trainings.Business
{
    using System;
    using Trainings.Business.Assembler;
    using Trainings.Business.Interface;
    using Trainings.Data.Models;
    using Trainings.Repository.Interfaces;
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

        public User SignUp(SignUpViewModel signUpViewModel)
        {           
            User user = _authRepository.SignUp(signUpViewModel.SignUpViewModelToUser());
            return user;
        }

        #endregion
    }
}
