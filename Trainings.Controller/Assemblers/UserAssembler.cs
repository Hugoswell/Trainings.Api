using Trainings.ViewModel;

namespace Trainings.Controller.Assembler
{
    internal static class UserAssembler
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
    }
}
