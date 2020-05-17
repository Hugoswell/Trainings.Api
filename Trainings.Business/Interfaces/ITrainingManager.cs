namespace Trainings.Business.Interfaces
{
    using System.Collections.Generic;
    using Trainings.Model.Models;

    public interface ITrainingManager
    {
        int? Create(int userId);

        IEnumerable<TrainingInfoModel> GetTrainingsInfo(int userId);

        IEnumerable<TrainingInfoModel> GetThreeLastTrainingsInfo(int userId);

        TrainingModel GetTraining(int userId, int trainingId);
    }
}
