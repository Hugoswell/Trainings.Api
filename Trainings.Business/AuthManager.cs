namespace Trainings.Business
{
    using System;
    using Trainings.Business.Helper;
    using Trainings.Business.Interface;
    using Trainings.Model.Models;
    using Trainings.Repository.Interfaces;

    public class AuthManager : IAuthManager
    {
        #region Constructor & Properties

        private readonly IAuthRepository _authRepository;

        public AuthManager(IAuthRepository authRepository)
        {
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        }

        #endregion        

        public UserModel SignUp(UserModel userModel)
        {
            userModel.Password = Hasher.HashPassword(userModel.Password, Hasher.CreateSalt());
            userModel.RoleId = 0;
            userModel.RoleName = "free";
            UserModel userManagerModelResult = _authRepository.SignUp(userModel);
            return userManagerModelResult;
        }

        public UserModel SignIn(UserModel userModel)
        {
            userModel.Password = Hasher.HashPassword(userModel.Password, Hasher.CreateSalt());
            UserModel userModelResult = _authRepository.SignIn(userModel);
            return userModelResult;
        }
    }
}
