namespace Trainings.Repository.Assemblers
{
    using Trainings.Common.Helpers;
    using Trainings.Data.Tables;
    using Trainings.Model.Models;

    internal static class UserRepositoryAssembler
    {
        internal static User ToUser(this UserModel userModel)
        {
            return new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                HashedPassword = userModel.Password,
                RoleCode = userModel.RoleCode
            };
        }

        internal static UserModel ToUserModel(this User user)
        {
            if (user.IsNull())
            {
                return null;
            }

            return new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                RoleCode = user.RoleCode
            };
        }
    }
}
