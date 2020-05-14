namespace Trainings.Repository.Interfaces
{
    using System.Collections.Generic;

    public interface IExerciceRepository
    {
        IEnumerable<int> GetFilteredExercicesId(int userId);
    }
}
