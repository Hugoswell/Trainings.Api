using Trainings.Data.Models;
using Trainings.Repository.Interface;

namespace Trainings.Repository
{
    public class RegisterRepository : BaseRepository, IRegisterRepository
    {
        public RegisterRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public void RegisterUser(User user)
        {
            _trainingsEntities.User.Add(user);
            _trainingsEntities.SaveChanges();
        }
    }
}
