using Trainings.Data.Models;

namespace Trainings.Repository.Interface
{
    public interface IAuthRepository
    {
        void SignUp(User user);
    }
}
