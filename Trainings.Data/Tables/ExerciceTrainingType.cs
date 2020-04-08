using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class ExerciceTrainingType
    {
        [Key]
        public short ExerciceId { get; set; }
        [Key]
        public byte TrainingTypeId { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceTrainingType")]
        public virtual Exercice Exercice { get; set; }
        [ForeignKey(nameof(TrainingTypeId))]
        [InverseProperty("ExerciceTrainingType")]
        public virtual TrainingType TrainingType { get; set; }
    }
}
