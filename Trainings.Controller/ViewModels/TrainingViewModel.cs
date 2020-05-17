namespace Trainings.Controller.ViewModels
{
    using System.Collections.Generic;

    public class TrainingViewModel
    {
        public string TrainingTypeName { get; set; }

        public string NbTimes { get; set; }

        public string Duration { get; set; }

        public string CreationDate { get; set; }

        public IEnumerable<ExerciceTrainingViewModel> ExerciceTrainingViewModels { get; set; }
    }
}
