namespace Trainings.Repository.Assemblers
{
    using System.Collections.Generic;
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
                Id = training.Id,
                CreationDate = training.CreationDate,
                Duration = training.Duration,
                TrainingTypeId = training.TrainingTypeId
            };
        }

        internal static TrainingModel ToTrainingModel(this Training training)
        {
            return new TrainingModel
            {
                CreationDate = training.CreationDate,
                Duration = training.Duration,
                TrainingTypeId = training.TrainingTypeId,
                NbTimes = training.NbTimes,
                ExerciceTrainingModels = training.ExerciceTraining.ToExerciceTrainingModels()
            };
        }

        #region Private

        private static IEnumerable<ExerciceTrainingModel> ToExerciceTrainingModels(
            this IEnumerable<ExerciceTraining> exerciceTrainings)
        {
            List<ExerciceTrainingModel> exerciceTrainingModels = new List<ExerciceTrainingModel>();

            foreach (ExerciceTraining exerciceTraining in exerciceTrainings)
            {
                ExerciceTrainingModel exerciceTrainingModel = exerciceTraining.ToExerciceTrainingModel();
                exerciceTrainingModels.Add(exerciceTrainingModel);
            }

            return exerciceTrainingModels;
        }

        #endregion
    }
}
