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
        [StringLength(40)]
        public string TrainingTypeCode { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceTrainingType")]
        public virtual Exercice Exercice { get; set; }
        [ForeignKey(nameof(TrainingTypeCode))]
        [InverseProperty(nameof(TrainingType.ExerciceTrainingType))]
        public virtual TrainingType TrainingTypeCodeNavigation { get; set; }
    }
}
