using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class ExerciceMuscleGroup
    {
        [Key]
        public int ExerciceId { get; set; }
        [Key]
        [StringLength(35)]
        public string MuscleGroup { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceMuscleGroup")]
        public virtual Exercice Exercice { get; set; }
        [ForeignKey(nameof(MuscleGroup))]
        [InverseProperty("ExerciceMuscleGroup")]
        public virtual MuscleGroup MuscleGroupNavigation { get; set; }
    }
}
