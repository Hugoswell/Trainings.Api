namespace Trainings.Business
{
    using System;
    using Trainings.Business.Assembler;
    using Trainings.Business.Interface;
    using Trainings.Business.Models;
    using Trainings.Data.Models;
    using Trainings.Repository.Interfaces;

    public class AuthManager : IAuthBusiness
    {
        #region Constructor & Properties

        private readonly IAuthRepository _authRepository;

        public AuthManager(IAuthRepository authRepository)
        {
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        }

        #endregion

        #region SignUp

        public UserManagerModel SignUp(UserManagerModel userManagerModel)
        {           
            User user = _authRepository.SignUp(userManagerModel.ToUser());
            return user.ToUserManagerModel();
        }

        #endregion
    }
}
