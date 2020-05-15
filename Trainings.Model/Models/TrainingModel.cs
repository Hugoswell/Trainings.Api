namespace Trainings.Model.Models
{
    using System;
    using System.Collections.Generic;

    public class TrainingModel
    {
        public int UserPreferencesId { get; set; }

        public byte TrainingTypeId { get; set; }

        public byte? NbTimes { get; set; }

        public byte Duration { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public string CreatedBy { get; set; }

        public IEnumerable<ExerciceTrainingModel> ExerciceTrainingModels { get; set; }
    }
}
