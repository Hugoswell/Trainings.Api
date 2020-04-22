namespace Trainings.Business.Interfaces
{
    using Trainings.Model.Models;

    public interface IAuthManager
    {
        public TokenModel SignUp(SignUpModel signUpModel);

        public TokenModel SignIn(SignInModel signInModel);
    }
}
