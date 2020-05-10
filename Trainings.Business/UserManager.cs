namespace Trainings.Business
{
    using Trainings.Business.Interfaces;
    using Trainings.Repository.Interfaces;

    public class UserManager : IUserManager
    {
        #region Properties & Constructor

        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        public bool? GetHasFilledInfo(int userId)
        {
            return _userRepository.GetHasFilledInfo(userId);
        }
    }
}
