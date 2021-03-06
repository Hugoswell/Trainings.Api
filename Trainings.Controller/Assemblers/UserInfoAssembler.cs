﻿namespace Trainings.Controller.Assemblers
{
    using System;
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;

    internal static class UserInfoAssembler
    {
        internal static UserInfoModel ToUserModel(this UserInfoViewModel userViewModel, string userId)
        {
            return new UserInfoModel
            {
                Age = (byte)int.Parse(userViewModel.Age),
                Bmi = ComputeBMI(userViewModel.Weight, userViewModel.Height),
                EquipmentId = (byte)int.Parse(userViewModel.EquipmentId),
                GoalId = (byte)int.Parse(userViewModel.GoalId),
                Height = float.Parse(userViewModel.Height),
                LevelId = (byte)int.Parse(userViewModel.LevelId),
                SexId = (byte)int.Parse(userViewModel.SexId),
                TrainingDurationId = (byte)int.Parse(userViewModel.TrainingDurationId),
                TrainingTypeId = (byte)int.Parse(userViewModel.TrainingTypeId),
                UserId = int.Parse(userId),
                Weight = float.Parse(userViewModel.Weight)
            };
        }

        internal static UserInfoViewModel ToUserInfoViewModel(this UserInfoModel userInfoModel)
        {
            return new UserInfoViewModel
            {
                Age = userInfoModel.Age.ToString(),
                EquipmentId = userInfoModel.EquipmentId.ToString(),
                GoalId = userInfoModel.GoalId.ToString(),
                Height = userInfoModel.Height.ToString(),
                LevelId = userInfoModel.LevelId.ToString(),
                SexId = userInfoModel.SexId.ToString(),
                TrainingDurationId = userInfoModel.TrainingDurationId.ToString(),
                TrainingTypeId = userInfoModel.TrainingTypeId.ToString(),
                Weight = userInfoModel.Weight.ToString()
            };
        }

        #region Private

        private static float ComputeBMI(string weight, string height)
        {
            double weightD = Convert.ToDouble(weight);
            double heightD = int.Parse(height);
            return (float)(weightD / Math.Pow(heightD, 2)) * 10000;
        }       

        #endregion
    }
}
