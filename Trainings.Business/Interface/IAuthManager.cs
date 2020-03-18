using Trainings.Model.Models;

namespace Trainings.Business.Interface
{
    public interface IAuthManager
    {
        public UserModel SignUp(UserModel userManagerModel);

        public UserModel SignIn(UserModel userModel);
    }
}
