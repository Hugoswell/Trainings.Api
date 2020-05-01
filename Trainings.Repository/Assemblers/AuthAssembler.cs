namespace Trainings.Repository.Assemblers
{
    using System;
    using Trainings.Common.Helpers;
    using Trainings.Data.Tables;
    using Trainings.Model.Models;

    internal static class AuthAssembler
    {
        internal static User ToUser(this SignUpModel signUpModel)
        {
            return new User
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                HashedPassword = signUpModel.Password,
                RoleCode = signUpModel.RoleCode,
                HasFilledInformation = signUpModel.HasFilledInformation,
                FillInformationDate = signUpModel.FillInformationDate,
                CreationDate = DateTime.UtcNow
            };
        }

        internal static TokenModel ToTokenModel(this User user)
        {
            if (user.IsNull())
            {
                return null;
            }

            return new TokenModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                RoleCode = user.RoleCode,
                HasFilledInformation = user.HasFilledInformation
            };
        }
    }
}
