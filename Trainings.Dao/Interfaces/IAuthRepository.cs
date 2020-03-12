namespace Trainings.Repository.Interfaces
{
    using Trainings.Model.Models;

    public interface IAuthRepository
    {
        public UserModel SignUp(UserModel user);
    }
}
