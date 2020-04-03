using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class ExerciceTraining
    {
        [Key]
        public int Id { get; set; }
        public short ExerciceId { get; set; }
        public int TrainingId { get; set; }
        public byte? NbSets { get; set; }
        public byte? NbReps { get; set; }
        public double EffortDuration { get; set; }
        public double RestDuration { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceTraining")]
        public virtual Exercice Exercice { get; set; }
        [ForeignKey(nameof(TrainingId))]
        [InverseProperty("ExerciceTraining")]
        public virtual Training Training { get; set; }
    }
}
