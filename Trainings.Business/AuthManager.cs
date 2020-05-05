namespace Trainings.Business
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

        public TokenModel SignUp(SignUpModel signUpModel)
        {
            signUpModel.Password = _hasher.HashPassword(signUpModel.Password);
            signUpModel.RoleCode = AuthConstants.FreeRole;
            signUpModel.HasFilledInformation = false;
            signUpModel.FillInformationDate = null;

            TokenModel tokenModel = _authRepository.SignUp(signUpModel);
            
            if (!tokenModel.IsNull())
            {
                tokenModel.JwtToken = _jwtTokenHelper.GenerateJwtToken(
                    tokenModel.Id.ToString(), AuthConstants.FreeRole, tokenModel.FirstName, false, 1400);
                return tokenModel;
            }
            else
            {
                return null;
            }
        }

        public TokenModel SignIn(SignInModel signInModel)
        {
            signInModel.Password = _hasher.HashPassword(signInModel.Password);

            TokenModel tokenModel = _authRepository.SignIn(signInModel);
            
            if (!tokenModel.IsNull())
            {
                tokenModel.JwtToken = _jwtTokenHelper.GenerateJwtToken(
                    tokenModel.Id.ToString(), tokenModel.RoleCode, tokenModel.FirstName, tokenModel.HasFilledInformation, 60);
                return tokenModel;
            }
            else
            {
                return null;
            }
        }
    }
}
