using Trainings.Model.Models;

namespace Trainings.Business.Interfaces
{
    public interface IUserInfoManager
    {
        UserInfoModel Get(int userId);

        int? Create(UserInfoModel usermodel);
    }
}
