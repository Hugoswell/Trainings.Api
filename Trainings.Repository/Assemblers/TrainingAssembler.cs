namespace Trainings.Repository.Assemblers
{
    using Trainings.Data.Tables;
    using Trainings.Model.Models;

    internal static class TrainingAssembler
    {
        internal static Training ToTraining(this TrainingModel trainingModel)
        {
            return new Training
            {
                CreatedBy = trainingModel.CreatedBy,
                CreationDate = trainingModel.CreationDate,
                Duration = trainingModel.Duration,
                NbTimes = trainingModel.NbTimes,
                TrainingTypeId = trainingModel.TrainingTypeId,
                UserPreferencesId = trainingModel.UserPreferencesId
            };
        }

        internal static ExerciceTraining ToExerciceTraining(this ExerciceTrainingModel exerciceTrainingModel, int trainingId)
        {
            return new ExerciceTraining
            {
                ExerciceId = exerciceTrainingModel.ExerciceId,
                TrainingId = trainingId,
                NbSets = exerciceTrainingModel.NbSets,
                NbReps = exerciceTrainingModel.NbReps,
                RestDuration = exerciceTrainingModel.RestDuration,
                EffortDuration = exerciceTrainingModel.EffortDuration,
            };
        }

        internal static TrainingInfoModel ToTrainingInfoModel(this Training training)
        {
            return new TrainingInfoModel
            {
                CreationDate = training.CreationDate,
                Duration = training.Duration,
                TrainingTypeId = training.TrainingTypeId
            };
        }
    }
}
