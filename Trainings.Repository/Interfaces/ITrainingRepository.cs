namespace Trainings.Repository.Interfaces
{
    using Trainings.Model.Models;

    public interface ITrainingRepository
    {
        int? Create(TrainingModel trainingModel);
    }
}
