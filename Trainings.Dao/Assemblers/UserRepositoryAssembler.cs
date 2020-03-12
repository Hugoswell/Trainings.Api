﻿using Trainings.Data.Tables;
using Trainings.Model.Models;

namespace Trainings.Repository.Assemblers
{
    internal static class UserRepositoryAssembler
    {
        internal static User ToUser(this UserModel userModel)
        {
            return new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = userModel.Password,
                RoleId = userModel.RoleId,
                RoleName = userModel.RoleName
            };
        }
    }
}
