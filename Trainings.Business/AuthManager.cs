﻿namespace Trainings.Business
{
    using Trainings.Business.Interfaces;
    using Trainings.Common.Constants;
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
            userModel.RoleCode = AuthConstants.FreeRole;
            userModel.HasFillInformation = false;
            userModel.FillInformationDate = null;

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
                userModelResult.JwtToken = _jwtTokenHelper.GenerateJwtToken(userModelResult.RoleCode, 60);
                return userModelResult;
            }
            else
            {
                return null;
            }
        }
    }
}
