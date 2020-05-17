namespace Trainings.Repository
{
    using System;
    using System.Linq;
    using Trainings.Data.Context;
    using Trainings.Data.Tables;
    using Trainings.Model.Models;
    using Trainings.Repository.Assemblers;
    using Trainings.Repository.Interfaces;

    public class UserPreferencesRepository : BaseRepository, IUserPreferencesRepository
    {
        public UserPreferencesRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public UserPreferencesModel Get(int userId)
        {
            try
            {
                UserPreferences userPreferences = _trainingsEntities.UserPreferences
                    .Where(userPreferences => userPreferences.UserId.Equals(userId))
                    .First();
                return userPreferences.ToUserPreferencesModel();
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
