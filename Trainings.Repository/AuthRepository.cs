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

        public TokenModel SignUp(SignUpModel signUpModel)
        {
            try
            {
                User user = signUpModel.ToUser();
                _trainingsEntities.User.Add(user);
                _trainingsEntities.SaveChanges();
                return user.ToTokenModel();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TokenModel SignIn(SignInModel signInModel)
        {
            User user = _trainingsEntities.User
                .Where(user => user.Email.Equals(signInModel.Email)
                    && user.HashedPassword.Equals(signInModel.Password))
                .FirstOrDefault();

            return user.ToTokenModel();
        }
    }
}
