namespace Trainings.Repository.Interfaces
{
    using Trainings.Model.Models;

    public interface IAuthRepository
    {
        public UserModel SignUp(UserModel user);

        public UserModel SignIn(UserModel userModel);
    }
}
