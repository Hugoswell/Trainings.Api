using Trainings.Model.Models;

namespace Trainings.Business.Interfaces
{
    public interface IUserInfoManager
    {
        int? Create(UserInfoModel usermodel);
    }
}
