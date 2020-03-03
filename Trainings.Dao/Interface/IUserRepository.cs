using Trainings.Data.Models;

namespace Trainings.Repository.Interface
{
    public interface IUserRepository
    {
        void SignUp(User user);
    }
}
