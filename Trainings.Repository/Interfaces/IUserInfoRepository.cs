using Trainings.Model.Models;

namespace Trainings.Repository.Interfaces
{
    public interface IUserInfoRepository
    {
        UserInfoModel Get(int userId);

        int? Create(UserInfoModel userModel);

        int? Update(UserInfoModel userInfoModel);
    }
}
