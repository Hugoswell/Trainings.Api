using Trainings.Data.Models;
using Trainings.ViewModel;

namespace Trainings.Business.Interface
{
    public interface IAuthBusiness
    {
        User SignUp(SignUpViewModel signUpViewModel);
    }
}
