namespace Trainings.Controller.Assembler
{
    using Trainings.Common.Helpers;
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;

    internal static class UserControllerAssembler
    {
        internal static UserModel BuildUserModel(string email, string password, string firstName = null, string lastName = null)
        {
            return new UserModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
        }

        internal static UserViewModel ToUserViewModel(this UserModel userModel)
        {
            if (userModel.IsNull())
            {
                return null;
            }

            return new UserViewModel
            {
                Id = userModel.Id,
                Email = userModel.Email,
                JwtToken = userModel.JwtToken
            };
        }
    }
}
