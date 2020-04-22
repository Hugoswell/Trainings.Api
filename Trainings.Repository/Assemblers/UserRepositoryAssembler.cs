namespace Trainings.Repository.Assemblers
{
    using System;
    using Trainings.Common.Helpers;
    using Trainings.Data.Tables;
    using Trainings.Model.Models;

    internal static class UserRepositoryAssembler
    {
        internal static User ToUser(this SignUpModel userModel)
        {
            return new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                HashedPassword = userModel.Password,
                RoleCode = userModel.RoleCode,
                HasFillInformation = userModel.HasFillInformation,
                FillInformationDate = userModel.FillInformationDate,
                CreationDate = DateTime.UtcNow
            };
        }

        internal static SignUpModel ToUserModel(this User user)
        {
            if (user.IsNull())
            {
                return null;
            }

            return new SignUpModel
            {
                Id = user.Id,
                Email = user.Email,
                RoleCode = user.RoleCode
            };
        }
    }
}
