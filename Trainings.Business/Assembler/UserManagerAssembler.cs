using Trainings.Business.Helper;
using Trainings.Business.Models;
using Trainings.Common.Helpers;
using Trainings.Data.Models;

namespace Trainings.Business.Assembler
{
    internal static class UserManagerAssembler
    {
        internal static User ToUser(this UserManagerModel userManagerModel)
        {
            return new User
            {
                FirstName = userManagerModel.FirstName,
                LastName = userManagerModel.LastName,
                Email = userManagerModel.Email,
                Password = Hasher.HashPassword(userManagerModel.Password, Hasher.CreateSalt()),
                RoleId = 0,
                RoleName = "free"
            };
        }

        internal static UserManagerModel ToUserManagerModel(this User user)
        {
            if (user.IsNull())
            {
                return null;
            }

            return new UserManagerModel
            {
                Id = user.Id,
                RoleId = user.RoleId,
                RoleName = user.RoleName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
