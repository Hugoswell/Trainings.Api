using Trainings.Model.Models;

namespace Trainings.Repository.Interfaces
{
    public interface IUserInfoRepository
    {
        int? Create(UserInfoModel userModel);
    }
}
