﻿namespace Trainings.Repository.Assemblers
{
    using System.Linq;
    using Trainings.Data.Tables;
    using Trainings.Model.Models;

    internal static class UserInfoAssembler
    {
        internal static UserInfoModel ToUserInfoModel(this User user)
        {

            UserPhysicalInformation userPhyscalInformation = user.UserPhysicalInformation.First();
            UserPreferences userPreferences = user.UserPreferences.First();

            return new UserInfoModel
            {                
                Age = userPhyscalInformation.Age,
                EquipmentId = userPreferences.EquipmentId,
                GoalId = userPreferences.GoalId,
                Height = userPhyscalInformation.Height,
                LevelId = userPhyscalInformation.LevelId,
                SexId = userPhyscalInformation.SexId,
                TrainingDurationId = userPreferences.TrainingDurationId,
                TrainingTypeId = userPreferences.TrainingTypeId,
                UserId = userPreferences.UserId,
                Weight = userPhyscalInformation.Weight
            };
        }

        internal static UserPreferences ToUserPreferences(this UserInfoModel userInfoModel)
        {
            return new UserPreferences
            {
                EquipmentId = userInfoModel.EquipmentId,
                GoalId = userInfoModel.GoalId,
                TrainingDurationId = userInfoModel.TrainingDurationId,
                TrainingTypeId = userInfoModel.TrainingTypeId,
                UserId = userInfoModel.UserId
            };
        }

        internal static UserPhysicalInformation ToUserPhysicalInformation(this UserInfoModel userInfoModel)
        {
            return new UserPhysicalInformation
            {
                Age = userInfoModel.Age,
                Bmi = userInfoModel.Bmi,
                Height = userInfoModel.Height,
                LevelId = userInfoModel.LevelId,
                SexId = userInfoModel.SexId,
                Weight = userInfoModel.Weight,
                UserId = userInfoModel.UserId
            };
        }
    }
}
