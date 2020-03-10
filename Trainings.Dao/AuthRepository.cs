namespace Trainings.Repository
{
    using System;
    using Trainings.Data.Context;
    using Trainings.Data.Models;
    using Trainings.Repository.Interfaces;

    public class AuthRepository : BaseRepository, IAuthRepository
    {
        public AuthRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public User SignUp(User user)
        {
            try
            {
                _trainingsEntities.User.Add(user);
                _trainingsEntities.SaveChanges();
                return user;
            }
            catch (Exception)
            {
                return null;
            }            
        }
    }
}
