namespace Trainings.Business
{
    using Trainings.Business.Constants;
    using Trainings.Business.Helper;
    using Trainings.Business.Interfaces;
    using Trainings.Common.Helpers;
    using Trainings.Model.Models;
    using Trainings.Repository.Interfaces;

    public class AuthManager : IAuthManager
    {
        #region Constructor & Properties

        private readonly IAuthRepository _authRepository;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly IHasher _hasher;

        public AuthManager(
            IAuthRepository authRepository,
            IJwtTokenHelper jwtTokenHelper,
            IHasher hasher)
        {
            _authRepository = authRepository;
            _jwtTokenHelper = jwtTokenHelper;
            _hasher = hasher;
        }

        #endregion        

        public UserModel SignUp(UserModel userModel)
        {
            userModel.Password = _hasher.HashPassword(userModel.Password);
            userModel.RoleId = 0;
            userModel.RoleName = AuthConstants.FreeRole;
            
            UserModel userModelResult = _authRepository.SignUp(userModel);
            
            if (!userModelResult.IsNull())
            {
                userModelResult.JwtToken = _jwtTokenHelper.GenerateJwtToken(AuthConstants.FreeRole, 60);
                return userModelResult;
            }
            else
            {
                return null;
            }            
        }

        public UserModel SignIn(UserModel userModel)
        {
            userModel.Password = _hasher.HashPassword(userModel.Password);

            UserModel userModelResult = _authRepository.SignIn(userModel);
            
            if (!userModelResult.IsNull())
            {
                userModelResult.JwtToken = _jwtTokenHelper.GenerateJwtToken(userModelResult.RoleName, 60);
                return userModelResult;
            }
            else
            {
                return null;
            }
        }
    }
}
