namespace Trainings.Business
{
    using Trainings.Business.Interfaces;
    using Trainings.Model.Models;
    using Trainings.Repository.Interfaces;

    public class UserInfoManager : IUserInfoManager
    {
        #region Properties & Constructor

        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoManager(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        #endregion

        public int? Create(UserInfoModel userInfoModel)
        {
            return _userInfoRepository.Create(userInfoModel);
        }
    }
}
