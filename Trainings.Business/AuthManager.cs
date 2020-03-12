namespace Trainings.Business
{
    using System;
    using Trainings.Business.Helper;
    using Trainings.Business.Interface;
    using Trainings.Model.Models;
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

        public UserModel SignUp(UserModel userManagerModel)
        {
            userManagerModel.Password = Hasher.HashPassword(userManagerModel.Password, Hasher.CreateSalt());
            userManagerModel.RoleId = 0;
            userManagerModel.RoleName = "free";
            UserModel userManagerModelResult = _authRepository.SignUp(userManagerModel);
            return userManagerModelResult;
        }

        #endregion
    }
}
