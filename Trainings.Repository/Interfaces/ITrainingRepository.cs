namespace Trainings.Repository.Interfaces
{
    using System.Collections.Generic;
    using Trainings.Model.Models;

    public interface ITrainingRepository
    {
        int? Create(TrainingModel trainingModel);

        IEnumerable<TrainingInfoModel> GetTrainingsInfo(int userId);

        IEnumerable<TrainingInfoModel> GetThreeLastTrainingsInfo(int userId);

        TrainingModel GetTraining(int userId, int trainingId);
    }
}
