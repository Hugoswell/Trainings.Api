namespace Trainings.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool? GetHasFilledInfo(int userId);
    }
}
