namespace Trainings.Model.Models
{
    public class ExerciceTrainingModel
    {
        public short ExerciceId { get; set; }

        public string ExerciceName { get; set; }

        public byte? NbSets { get; set; }

        public byte? NbReps { get; set; }

        public double EffortDuration { get; set; }

        public double RestDuration { get; set; }
    }
}
