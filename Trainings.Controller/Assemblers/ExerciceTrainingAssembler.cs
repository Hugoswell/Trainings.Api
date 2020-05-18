namespace Trainings.Controller.Assemblers
{
    using Trainings.Controller.ViewModels;
    using Trainings.Model.Models;

    internal static class ExerciceTrainingAssembler
    {
        internal static ExerciceTrainingViewModel ToExerciceTrainingViewModel(
            this ExerciceTrainingModel exerciceTrainingModel,
            string trainingTypeName)
        {
            double effortDuration = exerciceTrainingModel.EffortDuration;
            double restduration = exerciceTrainingModel.RestDuration;

            if (trainingTypeName.Equals("Crossfit") || trainingTypeName.Equals("HIIT"))
            {
                effortDuration = effortDuration.ToSeconds();
                restduration = 60 - effortDuration;
            }

            if (trainingTypeName.Equals("Musculation"))
            {
                restduration = restduration / exerciceTrainingModel.NbSets.Value;
            }

            return new ExerciceTrainingViewModel
            {
                EffortDuration = effortDuration.ToString(),
                ExerciceName = exerciceTrainingModel.ExerciceName,
                NbReps = exerciceTrainingModel.NbReps.ToString(),
                NbSets = exerciceTrainingModel.NbSets.ToString(),
                RestDuration = restduration.ToString()
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

        #endregion
    }
}
