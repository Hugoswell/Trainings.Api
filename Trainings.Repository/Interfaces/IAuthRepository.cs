namespace Trainings.Repository.Interfaces
{
    using Trainings.Model.Models;

    public interface IAuthRepository
    {
        public TokenModel SignUp(SignUpModel signUpModel);

        public TokenModel SignIn(SignInModel signInModel);
    }
}
