using Trainings.Common.Helpers;
using Trainings.Controller.ViewModels;
using Trainings.Model.Models;

namespace Trainings.Controller.Assembler
{
    internal static class UserControllerAssembler
    {
        internal static UserModel ToUserModel(string firstName, string lastName, string email, string password)
        {
            return new UserModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
        }

        internal static UserViewModel ToUserViewModel(this UserModel userManagerModel)
        {
            if (userManagerModel.IsNull())
            {
                return null;
            }

            return new UserViewModel
            {
                Id = userManagerModel.Id,
                Email = userManagerModel.Email
            };
        }
    }
}
