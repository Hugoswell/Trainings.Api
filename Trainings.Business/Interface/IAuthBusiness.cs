using Trainings.Business.Models;

namespace Trainings.Business.Interface
{
    public interface IAuthBusiness
    {
        public UserManagerModel SignUp(UserManagerModel userManagerModel);
    }
}
