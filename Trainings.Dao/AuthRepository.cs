namespace Trainings.Repository
{
    using System;
    using System.Linq;
    using Trainings.Data.Context;
    using Trainings.Data.Tables;
    using Trainings.Model.Models;
    using Trainings.Repository.Assemblers;
    using Trainings.Repository.Interfaces;

    public class AuthRepository : BaseRepository, IAuthRepository
    {
        public AuthRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public UserModel SignUp(UserModel userModel)
        {
            try
            {
                User user = userModel.ToUser();
                _trainingsEntities.User.Add(user);
                _trainingsEntities.SaveChanges();
                userModel.Id = user.Id;
                return userModel;
            }
            catch (Exception)
            {
                return null;
            }            
        }

        public UserModel SignIn(UserModel userModel)
        {
            User userResult = _trainingsEntities.User
                .Where(user => user.Email.Equals(userModel.Email)
                    && user.HashedPassword.Equals(userModel.Password))
                .FirstOrDefault();

            return userResult.ToUserModel();
        }
    }
}
