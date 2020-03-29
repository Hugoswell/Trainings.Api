namespace Trainings.Business.Interfaces
{
    using Trainings.Model.Models;

    public interface IAuthManager
    {
        public UserModel SignUp(UserModel userModel);

        public UserModel SignIn(UserModel userModel);
    }
}
