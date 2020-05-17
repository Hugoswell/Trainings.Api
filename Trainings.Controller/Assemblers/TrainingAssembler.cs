namespace Trainings.Controller.Assemblers
{
    using System.Collections.Generic;
    using System.Globalization;
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;

    internal static class TrainingAssembler
    {
        internal static TrainingInfoViewModel ToTrainingInfoViewModel(this TrainingInfoModel trainingInfoModel)
        {
            return new TrainingInfoViewModel
            {
                Id = trainingInfoModel.Id.ToString(),
                CreationDate = trainingInfoModel.CreationDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                Duration = trainingInfoModel.Duration.ToString(),
                TrainingTypeName = trainingInfoModel.TrainingTypeId.ToTrainingTypeName()
            };
        }

        internal static TrainingViewModel ToTrainingViewModel(this TrainingModel trainingModel)
        {
            return new TrainingViewModel
            {
                CreationDate = trainingModel.CreationDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                Duration = trainingModel.Duration.ToString(),
                NbTimes = trainingModel.NbTimes.ToString(),
                ExerciceTrainingViewModels = trainingModel.ExerciceTrainingModels.ToExerciceTrainingViewModels(),
                TrainingTypeName = trainingModel.TrainingTypeId.ToTrainingTypeName()
            };
        }

        #region Private

        private static IEnumerable<ExerciceTrainingViewModel> ToExerciceTrainingViewModels(
            this IEnumerable<ExerciceTrainingModel> exerciceTrainingModels)
        {
            List<ExerciceTrainingViewModel> exerciceTrainingViewModels = new List<ExerciceTrainingViewModel>();

            foreach (ExerciceTrainingModel exerciceTrainingModel in exerciceTrainingModels)
            {
                ExerciceTrainingViewModel exerciceTrainingViewModel = exerciceTrainingModel.ToExerciceTrainingViewModel();
                exerciceTrainingViewModels.Add(exerciceTrainingViewModel);
            }

            return exerciceTrainingViewModels;
        }

        private static string ToTrainingTypeName(this byte trainingTypeId)
        {
            return trainingTypeId switch
            {
                1 => "Musculation",
                2 => "Cardio",
                3 => "Crossfit",
                4 => "HIIT",
                _ => "",
            };
        }

        #endregion
    }
}
