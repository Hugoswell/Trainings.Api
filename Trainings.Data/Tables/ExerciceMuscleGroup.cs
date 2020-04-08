using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class ExerciceMuscleGroup
    {
        [Key]
        public short ExerciceId { get; set; }
        [Key]
        public byte MuscleGroupId { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceMuscleGroup")]
        public virtual Exercice Exercice { get; set; }
        [ForeignKey(nameof(MuscleGroupId))]
        [InverseProperty("ExerciceMuscleGroup")]
        public virtual MuscleGroup MuscleGroup { get; set; }
    }
}
