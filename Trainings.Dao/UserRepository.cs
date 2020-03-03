using Trainings.Data.Models;
using Trainings.Repository.Interface;

namespace Trainings.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public void SignUp(User user)
        {
            _trainingsEntities.User.Add(user);
            _trainingsEntities.SaveChanges();
        }
    }
}
