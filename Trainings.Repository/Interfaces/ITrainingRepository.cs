namespace Trainings.Repository.Interfaces
{
    using System.Collections.Generic;
    using Trainings.Model.Models;

    public interface ITrainingRepository
    {
        int? Create(TrainingModel trainingModel);

        IEnumerable<TrainingInfoModel> GetTrainingsInfo(int userId);
    }
}
