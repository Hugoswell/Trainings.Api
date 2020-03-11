using Trainings.Business.Models;
using Trainings.Common.Helpers;
using Trainings.ViewModel;

namespace Trainings.Controller.Assembler
{
    internal static class UserControllerAssembler
    {
        internal static SignUpViewModel ToSignUpViewModel(string firstName, string lastName, string email, string password)
        {
            return new SignUpViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
        }

        internal static UserManagerModel ToUserManagerModel(this SignUpViewModel signUpViewModel)
        {
            return new UserManagerModel
            {
                FirstName = signUpViewModel.FirstName,
                LastName = signUpViewModel.LastName,
                Email = signUpViewModel.Email,
                Password = signUpViewModel.Password,
            };
        }

        internal static UserViewModel ToUserViewModel(this UserManagerModel userManagerModel)
        {
            if (userManagerModel.IsNull())
            {
                return null;
            }

            return new UserViewModel
            {
                Id = userManagerModel.Id,
                RoleId = userManagerModel.RoleId,
                Email = userManagerModel.Email
            };
        }
    }
}
