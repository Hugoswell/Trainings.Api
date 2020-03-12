using Trainings.Model.Models;

namespace Trainings.Business.Interface
{
    public interface IAuthBusiness
    {
        public UserModel SignUp(UserModel userManagerModel);
    }
}
