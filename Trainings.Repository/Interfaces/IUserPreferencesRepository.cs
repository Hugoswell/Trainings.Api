namespace Trainings.Repository.Interfaces
{
    using Trainings.Model.Models;

    public interface IUserPreferencesRepository
    {
        UserPreferencesModel Get(int userId);
    }
}
