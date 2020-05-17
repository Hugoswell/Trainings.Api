namespace Trainings.Controller.Assemblers
{
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;

    internal static class ExerciceTrainingAssembler
    {
        internal static ExerciceTrainingViewModel ToExerciceTrainingViewModel(this ExerciceTrainingModel exerciceTrainingModel)
        {
            int effortDuration = exerciceTrainingModel.EffortDuration.ToSeconds();
            return new ExerciceTrainingViewModel
            {
                EffortDuration = effortDuration.ToString(),
                ExerciceName = exerciceTrainingModel.ExerciceName,
                NbReps = exerciceTrainingModel.NbReps.ToString(),
                NbSets = exerciceTrainingModel.NbSets.ToString(),
                RestDuration = ComputeRestDuration(effortDuration)
            };
        }

        #region Private

        private static int ToSeconds(this double durationInMinutes)
        {
            if (durationInMinutes >= 1)
            {
                return (int) durationInMinutes;
            }
            return (int) (durationInMinutes * 60);
        }

        private static string ComputeRestDuration(this int effortDuration)
        {
            return (60 - effortDuration).ToString();
        }

        #endregion
    }
}
