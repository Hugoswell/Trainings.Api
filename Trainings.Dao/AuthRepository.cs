using Trainings.Data.Context;
using Trainings.Data.Models;

namespace Trainings.Repository
{
    class AuthRepository : BaseRepository
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
