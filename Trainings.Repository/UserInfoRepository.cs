﻿namespace Trainings.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using Trainings.Data.Context;
    using Trainings.Data.Tables;
    using Trainings.Model.Models;
    using Trainings.Repository.Assemblers;
    using Trainings.Repository.Interfaces;

    public class UserInfoRepository : BaseRepository, IUserInfoRepository
    {
        public UserInfoRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public UserInfoModel Get(int userId)
        {
            try
            {
                User user = _trainingsEntities.User
                    .Where(user => user.Id.Equals(userId))
                    .Include(user => user.UserPreferences)
                    .Include(user => user.UserPhysicalInformation)
                    .First();
                return user.ToUserInfoModel();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public int? Create(UserInfoModel userInfoModel)
        {
            try
            {
                User user = _trainingsEntities.User.Find(userInfoModel.UserId);
                user.HasFilledInformation = true;
                user.FillInformationDate = DateTime.Now;

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

        public int? Update(UserInfoModel userInfoModel)
        {
            try
            {
                UserPreferences userPreferences = _trainingsEntities.UserPreferences
                    .Where(up => up.UserId.Equals(userInfoModel.UserId)).First();

                UserPhysicalInformation userPhysicalInformation = _trainingsEntities.UserPhysicalInformation
                    .Where(upi => upi.UserId.Equals(userInfoModel.UserId)).First();

                userPreferences.UpdateUserPreferences(userInfoModel);
                userPhysicalInformation.UpdateUserPhysicalInformation(userInfoModel);

                _trainingsEntities.UserPreferences.Update(userPreferences);                
                _trainingsEntities.UserPhysicalInformation.Update(userPhysicalInformation);
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
