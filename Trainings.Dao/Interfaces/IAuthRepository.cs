namespace Trainings.Repository.Interfaces
{
    using Trainings.Data.Models;

    public interface IAuthRepository
    {
        User SignUp(User user);
    }
}
