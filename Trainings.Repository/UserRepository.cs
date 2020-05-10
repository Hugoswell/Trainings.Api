namespace Trainings.Repository
{
    using System;
    using Trainings.Data.Context;
    using Trainings.Repository.Interfaces;

    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public bool? GetHasFilledInfo(int userId)
        {
            try
            {
                return _trainingsEntities.User.Find(userId).HasFilledInformation;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
