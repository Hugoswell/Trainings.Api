using Trainings.Data.Context;
using Trainings.Data.Models;
using Trainings.Repository.Interface;

namespace Trainings.Repository
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        public AuthRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public void SignUp(User user)
        {
            _trainingsEntities.User.Add(user);
            _trainingsEntities.SaveChanges();
        }
    }
}
