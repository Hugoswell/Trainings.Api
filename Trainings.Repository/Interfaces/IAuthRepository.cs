namespace Trainings.Repository.Interfaces
{
    using Trainings.Model.Models;

    public interface IAuthRepository
    {
        public SignUpModel SignUp(SignUpModel userModel);

        public SignUpModel SignIn(SignUpModel userModel);
    }
}
