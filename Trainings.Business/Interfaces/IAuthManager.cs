namespace Trainings.Business.Interfaces
{
    using Trainings.Model.Models;

    public interface IAuthManager
    {
        public UserModel SignUp(UserModel userManagerModel);

        public UserModel SignIn(UserModel userModel);
    }
}
