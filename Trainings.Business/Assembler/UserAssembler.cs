using Trainings.Business.Helper;
using Trainings.Data.Models;
using Trainings.ViewModel;

namespace Trainings.Business.Assembler
{
    internal static class UserAssembler
    {
        internal static User SignUpViewModelToUser(this SignUpViewModel signUpViewModel)
        {
            return new User
            {
                FirstName = signUpViewModel.FirstName,
                LastName = signUpViewModel.LastName,
                Email = signUpViewModel.Email,
                Password = Hasher.HashPassword(signUpViewModel.Password, Hasher.CreateSalt()),
                RoleId = 1,
                RoleName = "free"                
            };
        }
    }
}
