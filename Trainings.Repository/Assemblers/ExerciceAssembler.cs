namespace Trainings.Repository.Assemblers
{
    using Trainings.Data.Tables;
    using Trainings.Model.Models;

    internal static class ExerciceAssembler
    {
        internal static int ToInt(this short s)
        {
            return (int)s;
        }

        internal static ExerciceTrainingModel ToExerciceTrainingModel(
            this ExerciceTraining exerciceTraining)
        {
            return new ExerciceTrainingModel
            {
                ExerciceName = exerciceTraining.Exercice.Name,
                EffortDuration = exerciceTraining.EffortDuration,
                RestDuration = exerciceTraining.RestDuration,                
                NbReps = exerciceTraining.NbReps,
                NbSets = exerciceTraining.NbSets                
            };
        }
    }
}
