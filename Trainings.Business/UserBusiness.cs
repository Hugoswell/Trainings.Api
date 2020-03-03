using System;
using Trainings.Business.Assembler;
using Trainings.Business.Interface;
using Trainings.Data.Models;
using Trainings.Repository.Interface;
using Trainings.ViewModel;

namespace Trainings.Business
{
    public class UserBusiness : IUserBusiness
    {
        #region Constructor & Properties

        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        #endregion

        #region SignUp

        public void SignUp(SignUpViewModel signUpViewModel)
        {
            User user = signUpViewModel.SignUpViewModelToUser();
            _userRepository.SignUp(user);
        }

        #endregion
    }
}
