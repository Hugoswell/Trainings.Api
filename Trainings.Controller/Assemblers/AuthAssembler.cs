namespace Trainings.Controller.Assembler
{
    using Trainings.Common.Helpers;
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;

    internal static class AuthAssembler
    {
        internal static SignUpModel ToSignUpModel(this SignUpViewModel signUpViewModel)
        {
            return new SignUpModel
            {
                FirstName = signUpViewModel.FirstName,
                LastName = signUpViewModel.LastName,
                Email = signUpViewModel.Email,
                Password = signUpViewModel.Password
            };
        }

        internal static TokenViewModel ToTokenViewModel(this TokenModel tokenModel)
        {
            if (tokenModel.IsNull())
            {
                return null;
            }

            return new TokenViewModel
            {
                JwtToken = tokenModel.JwtToken
            };
        }
    }
}
