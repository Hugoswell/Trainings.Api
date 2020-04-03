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
        [StringLength(40)]
        public string GoalCode { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceGoal")]
        public virtual Exercice Exercice { get; set; }
        [ForeignKey(nameof(GoalCode))]
        [InverseProperty(nameof(Goal.ExerciceGoal))]
        public virtual Goal GoalCodeNavigation { get; set; }
    }
}
