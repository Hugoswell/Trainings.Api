using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class ExerciceGoal
    {
        [Key]
        public short ExerciceId { get; set; }
        [Key]
        public byte GoalId { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceGoal")]
        public virtual Exercice Exercice { get; set; }
        [ForeignKey(nameof(GoalId))]
        [InverseProperty("ExerciceGoal")]
        public virtual Goal Goal { get; set; }
    }
}
