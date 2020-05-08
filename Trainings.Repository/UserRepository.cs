namespace Trainings.Repository
{
    using System;
    using Trainings.Data.Context;
    using Trainings.Data.Tables;
    using Trainings.Model.Models;
    using Trainings.Repository.Assemblers;
    using Trainings.Repository.Interfaces;

    public class UserRepository : BaseRepository, IUserInfoRepository
    {
        public UserRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public int? Create(UserInfoModel userInfoModel)
        {
            try
            {
                UserPreferences userPreferences = userInfoModel.ToUserPreferences();
                UserPhysicalInformation userPhysicalInformation = userInfoModel.ToUserPhysicalInformation();

                _trainingsEntities.UserPreferences.Add(userPreferences);
                _trainingsEntities.UserPhysicalInformation.Add(userPhysicalInformation);
                _trainingsEntities.SaveChanges();

                return userInfoModel.UserId;
            }
            catch (Exception)
            {
                return null;
            }            
        }
    }
}
